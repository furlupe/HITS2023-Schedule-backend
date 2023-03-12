using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using System.Text.RegularExpressions;

namespace Schedule.Services.Classes
{
    public class EntityScheduleService : IEntityScheduleService
    {
        public LessonListDto CreateLessonResponse(ICollection<LessonScheduled> lessons)
        {
            var response = new List<LessonDTO>();
            foreach (var lesson in lessons)
            {
                response.Add(CreateSingleLessonResponse(lesson));
            }

            return new LessonListDto { Lessons = response };
        }

        public LessonDTO CreateSingleLessonResponse(LessonScheduled lesson)
        {
            List<int> groups = new();
            foreach (var group in lesson.BaseLesson.Groups)
            {
                groups.Add(group.Number);
            }

            var dateReplacemnt = new DateOnly();
            return new LessonDTO
            {
                Id = lesson.Id,
                Lesson = new LessonShortDto
                {
                    Id = lesson.BaseLesson.Id,
                    Teacher = new TeacherDTO
                    {
                        Name = lesson.BaseLesson.Teacher.Name,
                        Id = lesson.BaseLesson.Teacher.Id
                    },
                    Subject = lesson.BaseLesson.Subject.Name,
                    Groups = groups,
                    Type = lesson.BaseLesson.Type,
                    Cabinet = new CabinetDTO
                    {
                        Name = lesson.BaseLesson.Cabinet.Name,
                        Number = lesson.BaseLesson.Cabinet.Number
                    }
                },
                Timeslot = new TimeslotDTO
                {
                    Id = lesson.Timeslot.Id,
                    startAt = dateReplacemnt.ToDateTime(lesson.Timeslot.StartsAt),
                    endsAt = dateReplacemnt.ToDateTime(lesson.Timeslot.EndsAt)
                },
                Date = lesson.Date.ToDateTime(new TimeOnly(0, 0))
            };
        }
    }
}
