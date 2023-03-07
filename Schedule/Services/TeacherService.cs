using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Utils;
using System;

namespace Schedule.Services
{
    public class TeacherService: ITeacherService
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
                    Id= teacher.Id,
                    Name = teacher.Name
                });
            }
            return response;
        }

        public async Task<List<LessonDTO>> GetSchedule(Guid id, DateTime start, DateTime end)
        {
            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);
            var response = new List<LessonDTO>();
            var lessons = await _context.Lessons.
                Include(cab => cab.Cabinet).
                Include(sub => sub.Subject).
                Include(th => th.Teacher).
                Include(gr => gr.Groups).
                Include(ts => ts.Timeslot).
                Where(x => x.Teacher.Id == id && 
                x.DateFrom >= startDate &&
                    x.DateUntil <= endDate).ToListAsync();
            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Groups)
                {
                    groups.Add(group.Number);
                }

                var dateReplacemnt = new DateOnly();
                response.Add(new LessonDTO
                {
                    Subject = lesson.Subject.Name,
                    Cabinet = new CabinetDTO
                    {
                        Number = lesson.Cabinet.Number,
                        Name = lesson.Cabinet.Name
                    },
                    GroupsNum = groups,
                    Teacher = lesson.Teacher.Name,
                    Start = dateReplacemnt.ToDateTime(lesson.Timeslot.StartsAt),
                    End = dateReplacemnt.ToDateTime(lesson.Timeslot.EndsAt)
                });
            }
            return response;
        }
    }
}
