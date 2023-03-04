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
            List<Group> groups = new List<Group>();
            foreach (var num in lesson.GroupsNum)
            {
                groups.Add(await _context.Groups.FirstOrDefaultAsync(x => x.Number == num));
            }
            await _context.Lessons.AddAsync(new Lesson
            {
                Date = lesson.Date,
                Timeslot = await _context.Timeslots.FirstOrDefaultAsync(x => x.Id == lesson.TimeslotId),
                Cabinet = await _context.Cabinets.FirstOrDefaultAsync(x => x.Number == lesson.CabinetNum),
                Groups = groups,
                Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == lesson.SubjectId),
                Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == lesson.TeacherId)
            });
            await _context.SaveChangesAsync();
        }

        public async Task EditLesson(LessonCreateDTO lesson, Guid id)
        {
            List<Group> groups = new List<Group>();
            foreach (var num in lesson.GroupsNum)
            {
                groups.Add(await _context.Groups.FirstOrDefaultAsync(x => x.Number == num));
            }
            var thisLesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);
            if (thisLesson == null)
            {
                //TODO: Exeption
            }
            thisLesson.Date = lesson.Date;
            thisLesson.Timeslot = await _context.Timeslots.FirstOrDefaultAsync(x => x.Id == lesson.TimeslotId);
            thisLesson.Cabinet = await _context.Cabinets.FirstOrDefaultAsync(x => x.Number == lesson.CabinetNum);
            thisLesson.Groups = groups;
            thisLesson.Subject = await _context.Subjects.FirstOrDefaultAsync(x => x.Id == lesson.SubjectId);
            thisLesson.Teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == lesson.TeacherId);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLesson(Guid id)
        {
            var lesson = await _context.Lessons.FirstOrDefaultAsync(x => x.Id == id);
            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();
        }
    }
}
