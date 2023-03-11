using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class EntityScheduleService : IEntityScheduleService
    {
        public LessonListDto CreateLessonResponse(ICollection<LessonScheduled> lessons)
        {
            var response = new List<LessonDTO>();
            foreach (var lesson in lessons)
            {
                List<int> groups = new();
                foreach (var group in lesson.BaseLesson.Groups)
                {
                    groups.Add(group.Number);
                }

                var dateReplacemnt = new DateOnly();
                response.Add(new LessonDTO
                {
                    Id = lesson.Id,
                    Lesson = new LessonShortDto
                    {
                        Id = lesson.BaseLesson.Id,
                        Teacher = lesson.BaseLesson.Teacher.Name,
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
                });
            }

            return new LessonListDto { Lessons = response };
        }
    }
}
