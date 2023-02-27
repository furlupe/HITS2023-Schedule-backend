using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
{
    public class CabinetService : ICabinetService
    {
        private readonly ApplicationContext _context;

        public CabinetService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<int>> GetAllCabinets()
        {
            var response = new List<int>();
            var cabinetModel = await _context.Cabinets.ToListAsync();
            foreach (var cabinet in cabinetModel)
            {
                response.Add(cabinet.Number);
            }
            return response;
        }

        public async Task<List<LessonDTO>> GetSchedule(int num, DateTime start, DateTime ends)
        {
            var response = new List<LessonDTO>();
            var lessons = await _context.Lessons.
                Include(cab => cab.Cabinet).
                Include(sub => sub.Subject).
                Include(th => th.Teacher).
                Include(gr => gr.Groups).
                Include(ts => ts.Timeslot).
                Where(x => x.Cabinet.Number == num && x.Timeslot.StartsAt >= start && x.Timeslot.EndsAt <= ends).ToListAsync();
            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Groups)
                {
                    groups.Add(group.Number);
                }

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
                    Start = lesson.Timeslot.StartsAt,
                    End = lesson.Timeslot.EndsAt
                });
            }
            return response;
        }
    }
}
