using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
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

            if (await LessonIntersects(newLesson))
                throw new BadHttpRequestException("Lesson intersects");

            await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync();
            await ScheduleLessons(newLesson);
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
            if (await LessonIntersects(newLesson, l.Id))
                throw new BadHttpRequestException("Lesson intersects");


            _context.Entry(l).CurrentValues.SetValues(new
            {
                Timeslot = newLesson.Timeslot,
                Cabinet = newLesson.Cabinet,
                Groups = newLesson.Groups,
                Subject = newLesson.Subject,
                Teacher = newLesson.Teacher,
                Day = newLesson.Day,
                Type = newLesson.Type,
                DateFrom = newLesson.DateFrom,
                DateUntil = newLesson.DateUntil
            });

            await _context.SaveChangesAsync();

            await _context.SaveChangesAsync();
            await RescheduleLessons(l);
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

            var timeslot = await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == data.Timeslot)
                ?? throw new BadHttpRequestException("No such timeslot");

            if (await _context.Lessons.AnyAsync(l => l.Teacher == teacher && l.Timeslot == timeslot && l.Day == data.Day))
            {
                throw new BadHttpRequestException("Teacher is occupied on that time");
            }

            var groups = await _context.Groups.Where(g => data.Groups.Contains(g.Number)).ToListAsync();
            var unaddedGroups = data.Groups.Except(groups.Select(g => g.Number));
            if (unaddedGroups.Any())
            {
                throw new BadHttpRequestException("No such groups with ids:");
            }

            if (await _context.Lessons.AnyAsync(l => l.Groups.Any(g => groups.Contains(g)) && l.Timeslot == timeslot && l.Day == data.Day))
            {
                throw new BadHttpRequestException(string.Format($"Groups are occupied on that time"));
            }

            return new Lesson
            {
                Type = data.Type,
                Day = data.Day,
                Teacher = teacher,
                Groups = groups,
                Subject = subject,
                Cabinet = cabinet,
                Timeslot = timeslot,
                DateFrom = DateOnly.FromDateTime(data.StartsAt),
                DateUntil = DateOnly.FromDateTime(data.EndsAt)
            };
        }
        private async Task<bool> LessonIntersects(Lesson lesson, Guid? ignore = null)
        {
            var lessonPeriod = new Period(lesson.DateFrom, lesson.DateUntil);
            foreach (var l in await _context.Lessons
                .Where(l =>
                    l.Day == lesson.Day &&
                    l.Cabinet == lesson.Cabinet &&
                    l.Timeslot == lesson.Timeslot && l.Id != ignore)
                .ToListAsync())
            {
                if (!lessonPeriod.IntersetsWith(new Period(l.DateFrom, l.DateUntil))) continue;

                return true;
            }

            return false;
        }
        private DateOnly GetClosestDateWithDay(DateOnly from, DayOfWeek day)
        {
            while (from.DayOfWeek != day) from = from.AddDays(1);

            return from;
        }
        private async Task RescheduleLessons(Lesson lesson)
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
            await ScheduleLessons(lesson);
        }
        private async Task ScheduleLessons(Lesson lesson)
        {
            var startDate = GetClosestDateWithDay(lesson.DateFrom, lesson.Day);
            for (; startDate <= lesson.DateUntil; startDate = startDate.AddDays(7))
            {
                await _context.ScheduledLessons.AddAsync(new LessonScheduled
                {
                    Lesson = lesson,
                    Date = startDate,
                    Timeslot = lesson.Timeslot
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}