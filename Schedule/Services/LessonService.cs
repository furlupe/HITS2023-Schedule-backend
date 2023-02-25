using Schedule.Models.DTO;
using Schedule.Models;
using Schedule.Utils;
using Microsoft.EntityFrameworkCore;

namespace Schedule.Services
{
    public class LessonService: ILessonService
    {
        private readonly ApplicationContext _context;

        public LessonService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateLesson(LessonCreateDTO lesson)
        {
            List<Group> groups= new List<Group>();
            foreach (var num in lesson.GroupsNum)
            {
                groups.Add(await _context.Groups.FirstOrDefaultAsync(x=> x.Number== num));
            }
            await _context.Lessons.AddAsync(new Lesson
            {
                Date = lesson.Date,
                Timeslot = await _context.Timeslots.FirstOrDefaultAsync(x=>x.Id == lesson.TimeslotId),
                Cabinet = await _context.Cabinets.FirstOrDefaultAsync(x=>x.Number == lesson.ClassroomNum),
                Groups = groups,
                Subject = await _context.Subjects.FirstOrDefaultAsync(x=>x.Id == lesson.SubjectId),
                Teacher = await _context.Teachers.FirstOrDefaultAsync(x=>x.Id == lesson.TeacherId)
            });
            await _context.SaveChangesAsync();
        }
    }
}
