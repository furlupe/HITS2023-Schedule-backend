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

            var lessonPeriod = new Period(lesson.StartsAt, lesson.EndsAt);
            foreach(var l in await _context.Lessons
                .Where(l => 
                    l.Day == lesson.Day && 
                    l.Cabinet.Number == lesson.Cabinet && 
                    l.Timeslot == timeslot)
                .ToListAsync())
            {
                if (!lessonPeriod.IntersetsWith(new Period(l.DateFrom, l.DateUntil))) continue;

                throw new BadHttpRequestException("Pair intersection");
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

            await _context.Lessons.AddAsync(newLesson);

            var startDate = newLesson.DateFrom;
            while (startDate.DayOfWeek != lesson.Day) 
            { 
                startDate = startDate.AddDays(1);
            }

            for (; startDate <= newLesson.DateUntil; startDate = startDate.AddDays(7))
            {
                await _context.ScheduledLessons.AddAsync(new LessonScheduled
                {
                    Lesson = newLesson,
                    Date = startDate
                });
            }
            await _context.SaveChangesAsync();
        }

        public async Task EditLesson(LessonCreateDTO lesson, Guid id)
        {

        }

        public async Task DeleteLesson(Guid id)
        {

        }

    }
}
