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
            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == lesson.Teacher)
                ?? throw new BadHttpRequestException("No such teacher");

            var subject = await _context.Subjects.SingleOrDefaultAsync(s => s.Id == lesson.Subject)
                ?? throw new BadHttpRequestException("No such subject");

            var cabinet = await _context.Cabinets.SingleOrDefaultAsync(c => c.Number == lesson.Cabinet)
                ?? throw new BadHttpRequestException("No such cabinet");

            var timeslot = await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == lesson.Timeslot)
                ?? throw new BadHttpRequestException("No such timeslot");

            var groups = await _context.Groups.Where(g => lesson.Groups.Contains(g.Number)).ToListAsync();
            var unaddedGroups = lesson.Groups.Except(groups.Select(g => g.Number));
            if (unaddedGroups.Any())
            {
                throw new BadHttpRequestException("No such groups with ids:");
            }

            var newLesson = new Lesson
            {
                Type = lesson.Type,
                Day = lesson.Day,
                Teacher = teacher,
                Groups = groups,
                Subject = subject,
                Cabinet = cabinet,
                Timeslot = timeslot,
                DateFrom = DateOnly.FromDateTime(lesson.StartsAt),
                DateUntil = DateOnly.FromDateTime(lesson.EndsAt)
            };

            if (await LessonIntersects(newLesson))
                throw new BadHttpRequestException("Lesson intersects");


            await _context.Lessons.AddAsync(newLesson);
            await _context.SaveChangesAsync();
            await ScheduleLessons(newLesson);
        }

        public async Task EditLesson(LessonCreateDTO lesson, Guid id)
        {

        }

        public async Task DeleteLesson(Guid id)
        {

        }

        private async Task<bool> LessonIntersects(Lesson lesson)
        {
            var lessonPeriod = new Period(lesson.DateFrom, lesson.DateUntil);
            foreach (var l in await _context.Lessons
                .Where(l =>
                    l.Day == lesson.Day &&
                    l.Cabinet == lesson.Cabinet &&
                    l.Timeslot == lesson.Timeslot)
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
        private async Task ScheduleLessons(Lesson lesson)
        {
            var startDate = GetClosestDateWithDay(lesson.DateFrom, lesson.Day);
            for (; startDate <= lesson.DateUntil; startDate = startDate.AddDays(7))
            {
                await _context.ScheduledLessons.AddAsync(new LessonScheduled
                {
                    Lesson = lesson,
                    Date = startDate
                });
            }
        }
    }
}