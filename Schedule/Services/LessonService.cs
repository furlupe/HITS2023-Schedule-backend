using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Resources;
using Schedule.Utils;

namespace Schedule.Services
{
    public class LessonService : ILessonService
    {
        private readonly IResource _resource;

        public LessonService(IResource resource)
        {
            _resource = resource;
        }

        public async Task CreateLesson(LessonCreateDTO lesson)
        {
            var teacher = await _resource.GetTeacher(lesson.Teacher);
            var subject = await _resource.GetSubject(lesson.Subject);
            var cabinet = await _resource.GetCabinet(lesson.Cabinet);
            var timeslot = await _resource.GetTimeslot(lesson.Timeslot);
            var groups = await _resource.GetGroups(lesson.Groups);

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

            await _resource.AddLesson(newLesson);
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
            foreach (var l in await _resource.GetSimilarLessons(lesson))
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
                await _resource.ScheduleLesson(new LessonScheduled
                {
                    Lesson = lesson,
                    Date = startDate
                });
            }
        }
    }
}
