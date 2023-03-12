using Microsoft.EntityFrameworkCore;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using System;

namespace Schedule.Services.Classes
{
    public class TeacherService : ITeacherService
    {
        private readonly ApplicationContext _context;
        private readonly IEntityScheduleService _educationalEntityService;

        public TeacherService(ApplicationContext context, IEntityScheduleService educationalEntityService)
        {
            _context = context;
            _educationalEntityService = educationalEntityService;
        }

        public async Task<TeacherListDto> GetAllTeachers()
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
            return new TeacherListDto { Teachers = response };
        }

        public async Task<LessonListDto> GetSchedule(Guid id, DateTime start, DateTime end)
        {
            var confir = await _context.Teachers.FirstOrDefaultAsync(c => c.Id == id) 
                ?? throw new BadHttpRequestException(
                    string.Format(
                        ErrorStrings.TEACHER_WRONG_ID_ERROR, id),
                        StatusCodes.Status404NotFound
                        );

            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);

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

            return _educationalEntityService.CreateLessonResponse(lessons);
        }

        public async Task<LessonListDto> GetUserSchedule(Guid id, DateTime start, DateTime end)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == id);
            return await GetSchedule(user.TeacherProfile.Id, start, end);
        }

        public async Task<string> GetName(Guid id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
            if (teacher == null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.TEACHER_WRONG_ID_ERROR, id),
                    StatusCodes.Status404NotFound);
            }
            return teacher.Name;
        }

        public async Task AddTeacher(TeacherShortDto teacher)
        {
            await _context.Teachers.AddAsync(new Teacher
            {
                Name = teacher.Name
            });

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Guid id)
        {
            await _context.Teachers.Where(t => t.Id == id).ExecuteDeleteAsync();
        }
    }
}
