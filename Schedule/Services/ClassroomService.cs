using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationContext _context;
        
        public ClassroomService(ApplicationContext context) 
        {
            _context = context; 
        }

        public async Task<ClassroomListDTO> GetAllClassroom()
        {
            var response = new ClassroomListDTO();
            var classroomsModel = _context.Cabinets.ToList();
            foreach (var classroom in classroomsModel) 
            {
                response.Classrooms.Add(classroom.Name);
            }
            return response;
        }

        public async Task<ScheduleDTO> GetSchedule(int num, DateTime start, DateTime ends)
        {
            var response = new ScheduleDTO();
            var lessons = _context.Lessons.
                Include(cab => cab.Cabinet).ThenInclude(cab => cab.Name).
                Include(sub => sub.Subject).ThenInclude(sub => sub.Name).
                Include(th => th.Teacher).ThenInclude(th => th.Name).
                Include(gr => gr.Groups).ThenInclude(groups => groups.Number).
                Include(ts => ts.Timeslot).ThenInclude(timeslot => timeslot.StartsAt).
                Include(ts => ts.Timeslot).ThenInclude(timeslot => timeslot.EndsAt).
                Where(x => x.Cabinet.Number == num && x.Timeslot.StartsAt <= start && x.Timeslot.EndsAt >= ends).ToList();
            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Groups)
                {
                    groups.Add(group.Number);
                }

                response.Lessons.Add(new LessonDTO
                {
                    Name = lesson.Subject.Name,
                    Cabinet = lesson.Cabinet.Name,
                    Group = groups,
                    Teacher = lesson.Teacher.Name,
                    Start = lesson.Timeslot.StartsAt,
                    End= lesson.Timeslot.EndsAt
                });
            }
            return response;
        }
    }
}
