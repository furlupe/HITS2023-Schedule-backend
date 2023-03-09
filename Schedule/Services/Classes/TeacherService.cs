using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using System;

namespace Schedule.Services.Classes
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationContext _context;

        public TeacherService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TeacherDTO>> GetAllTeachers()
        {
            var response = new List<TeacherDTO>();
            var teachers = await _context.Teachers.ToListAsync();
            foreach (var teacher in teachers)
            {
                response.Add(new TeacherDTO
                {
                    Id = teacher.Id,
                    Name = teacher.Name
                });
            }
            return response;
        }

        public async Task<List<LessonDTO>> GetSchedule(Guid id, DateTime start, DateTime end)
        {
            var confir = await _context.Teachers.FirstOrDefaultAsync(c => c.Id == id);
            if (confir == null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.TEACHER_WRONG_ID_ERROR, id),
                    StatusCodes.Status404NotFound);
            }
            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);
            var response = new List<LessonDTO>();
            var lessons = await _context.ScheduledLessons.
                Include(x => x.Lesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.Lesson).ThenInclude(sub => sub.Subject).
                Include(x => x.Lesson).ThenInclude(th => th.Teacher).
                Include(x => x.Lesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Timeslot).
                Where(x => x.Date >= startDate &&
                x.Date <= endDate &&
                x.Lesson.Teacher.Id == id)
                .ToListAsync();

            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Lesson.Groups)
                {
                    groups.Add(group.Number);
                }

                var dateReplacemnt = new DateOnly();
                response.Add(new LessonDTO
                {
                    Type = lesson.Lesson.Type,
                    Subject = lesson.Lesson.Subject.Name,
                    Cabinet = new CabinetDTO
                    {
                        Number = lesson.Lesson.Cabinet.Number,
                        Name = lesson.Lesson.Cabinet.Name
                    },
                    Teacher = lesson.Lesson.Teacher.Name,
                    Timeslot = new TimeslotDTO
                    {
                        Id = lesson.Timeslot.Id,
                        startAt = dateReplacemnt.ToDateTime(lesson.Timeslot.StartsAt),
                        endsAt = dateReplacemnt.ToDateTime(lesson.Timeslot.EndsAt)
                    },
                    GroupsNum = groups,
                    Date = lesson.Date.ToDateTime(new TimeOnly(0, 0))
                });
            }
            return response;
        }
    }
}
