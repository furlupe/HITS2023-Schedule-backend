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
                Include(x => x.BaseLesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.BaseLesson).ThenInclude(sub => sub.Subject).
                Include(x => x.BaseLesson).ThenInclude(th => th.Teacher).
                Include(x => x.BaseLesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Timeslot).
                Where(x => x.Date >= startDate &&
                x.Date <= endDate &&
                x.BaseLesson.Teacher.Id == id)
                .ToListAsync();

            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
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
            return response;
        }
    }
}
