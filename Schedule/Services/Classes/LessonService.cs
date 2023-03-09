using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;

namespace Schedule.Services.Classes
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationContext _context;

        public LessonService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateLesson(LessonCreateDTO lesson)
        {
            var newLesson = await MakeLesson(lesson);
            var timeslot = await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == lesson.Timeslot)
                ?? throw new BadHttpRequestException("No such timeslot");

            var lessonPeriod = new Period(lesson.StartsAt, lesson.EndsAt);
            await CheckIfLessonIntersects(
                    newLesson,
                    lessonPeriod,
                    lesson.Day,
                    timeslot
                );

            await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync();

            await ScheduleLessons(
                    newLesson,
                    lessonPeriod,
                    lesson.Day,
                    timeslot
                );
        }

        public async Task EditSingleLesson(SingleLessonEditDto lesson, Guid id)
        {
            var l = await _context.ScheduledLessons.SingleOrDefaultAsync(l => l.Id == id)
                ?? throw new BadHttpRequestException("No such lesson");

            var timeslot = await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == lesson.TimeslotId)
                ?? throw new BadHttpRequestException("No such timeslot");

            if (await _context.ScheduledLessons.AnyAsync(
                les =>
                    les.Timeslot == timeslot &&
                    les.Date == DateOnly.FromDateTime(lesson.Date))
                )
            {
                throw new BadHttpRequestException("Lesson intersection");
            }

            l.Timeslot = timeslot;
            l.Date = DateOnly.FromDateTime(lesson.Date);
            await _context.SaveChangesAsync();
        }

        public async Task EditAllLessons(LessonCreateDTO lesson, Guid id)
        {
            var l = await _context.Lessons
                .SingleOrDefaultAsync(l => l.Id == id)
                ?? throw new BadHttpRequestException("No such lesson");

            var newLesson = await MakeLesson(lesson);
            var timeslot = await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == lesson.Timeslot)
                ?? throw new BadHttpRequestException("No such timeslot");

            var lessonPeriod = new Period(lesson.StartsAt, lesson.EndsAt);
            await CheckIfLessonIntersects(
                    newLesson,
                    lessonPeriod,
                    lesson.Day,
                    timeslot
                );

            _context.Entry(l).CurrentValues.SetValues(new
            {
                newLesson.Cabinet,
                newLesson.Groups,
                newLesson.Subject,
                newLesson.Teacher,
                newLesson.Type
            });

            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            await RescheduleLessons(l, lessonPeriod, lesson.Day, timeslot);
        }

        public async Task DeleteLesson(Guid id)
        {

        }

        private async Task<Lesson> MakeLesson(LessonCreateDTO data)
        {
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == data.Teacher)
                ?? throw new BadHttpRequestException("No such teacher");

            var subject = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == data.Subject)
                ?? throw new BadHttpRequestException("No such subject");

            var cabinet = await _context.Cabinets.SingleOrDefaultAsync(c => c.Number == data.Cabinet)
                ?? throw new BadHttpRequestException("No such cabinet");

            var groups = await _context.Groups.Where(g => data.Groups.Contains(g.Number)).ToListAsync();
            var unaddedGroups = data.Groups.Except(groups.Select(g => g.Number));
            if (unaddedGroups.Any())
            {
                throw new BadHttpRequestException("No such groups with ids:");
            }

            return new Lesson
            {
                Type = data.Type,
                Teacher = teacher,
                Groups = groups,
                Subject = subject,
                Cabinet = cabinet
            };
        }
        private async Task CheckIfLessonIntersects(Lesson lesson, Period period, DayOfWeek day, Timeslot timeslot)
        {
            var lessons = await _context.ScheduledLessons
                .Where(l =>
                        l.Date >= period.Start &&
                        l.Date <= period.End &&
                        l.Timeslot == timeslot &&
                        l.Date.DayOfWeek == day &&
                        l.Id != lesson.Id)
                .Include(l => l.Lesson.Cabinet)
                .Include(l => l.Lesson.Teacher)
                .Include(l => l.Lesson.Groups)
                .ToListAsync();

            if (lessons.Any(l => l.Lesson.Cabinet == lesson.Cabinet))
            {
                throw new BadHttpRequestException("Cabinet intersection");
            }

            if (lessons.Any(l => l.Lesson.Teacher == lesson.Teacher))
            {
                throw new BadHttpRequestException("Teacher intersection");
            }

            if (lessons.Any(l => l.Lesson.Groups.Any(g => lesson.Groups.Contains(g))))
            {
                throw new BadHttpRequestException(string.Format($"Groups are occupied on that time"));
            }

            return;
        }
        private DateOnly GetClosestDateWithDay(DateOnly from, DayOfWeek day)
        {
            while (from.DayOfWeek != day) from = from.AddDays(1);

            return from;
        }
        private async Task RescheduleLessons(Lesson lesson, Period period, DayOfWeek day, Timeslot timeslot)
        {
            var allScheduledLessons = await _context.ScheduledLessons
                .Where(les => les.Lesson == lesson)
                .ToListAsync();

            foreach (var sl in allScheduledLessons)
            {
                if (sl.Date < DateOnly.FromDateTime(DateTime.UtcNow)) continue;

                _context.ScheduledLessons.Remove(sl);
            }

            await _context.SaveChangesAsync();
            await ScheduleLessons(lesson, period, day, timeslot);
        }
        private async Task ScheduleLessons(Lesson lesson, Period period, DayOfWeek day, Timeslot timeslot)
        {
            var startDate = GetClosestDateWithDay(period.Start, day);
            for (; startDate <= period.End; startDate = startDate.AddDays(7))
            {
                await _context.ScheduledLessons.AddAsync(new LessonScheduled
                {
                    Lesson = lesson,
                    Date = startDate,
                    Timeslot = timeslot
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}