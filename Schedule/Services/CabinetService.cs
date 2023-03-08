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

        public async Task<List<LessonDTO>> GetSchedule(int num, DateTime starts, DateTime ends)
        {
            var startDate = DateOnly.FromDateTime(starts);
            var endDate = DateOnly.FromDateTime(ends);
            var response = new List<LessonDTO>();
            var lessons = await _context.ScheduledLessons.
                Include(x => x.Lesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.Lesson).ThenInclude(sub => sub.Subject).
                Include(x => x.Lesson).ThenInclude(th => th.Teacher).
                Include(x => x.Lesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Lesson).ThenInclude(ts => ts.Timeslot).
                Where(x => x.Date >= startDate && 
                x.Date <= endDate && 
                x.Lesson.Cabinet.Number == num)
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
                    Type = Convert.ToInt32(lesson.Lesson.Type),
                    Subject = lesson.Lesson.Subject.Name,
                    Cabinet = new CabinetDTO
                    {
                        Number = lesson.Lesson.Cabinet.Number,
                        Name = lesson.Lesson.Cabinet.Name
                    },
                    Teacher = lesson.Lesson.Teacher.Name,
                    Timeslot = new TimeslotDTO
                    {
                        startAt =  dateReplacemnt.ToDateTime(lesson.Lesson.Timeslot.StartsAt),
                        endsAt = dateReplacemnt.ToDateTime(lesson.Lesson.Timeslot.EndsAt)
                    },
                    GroupsNum = groups,
                    Date = lesson.Date
                });
            }
            return response;
        }
    }
}
