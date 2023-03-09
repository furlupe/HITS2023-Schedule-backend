using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
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
            var confir = await _context.Cabinets.FirstOrDefaultAsync(c => c.Number == num);
            if (confir == null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.CABINET_WRONG_ID_ERROR, num),
                    StatusCodes.Status404NotFound);
            }
            var startDate = DateOnly.FromDateTime(starts);
            var endDate = DateOnly.FromDateTime(ends);
            var response = new List<LessonDTO>();
            var lessons = await _context.ScheduledLessons.
                Include(x => x.BaseLesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.BaseLesson).ThenInclude(sub => sub.Subject).
                Include(x => x.BaseLesson).ThenInclude(th => th.Teacher).
                Include(x => x.BaseLesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Timeslot).
                Where(x => x.Date >= startDate &&
                x.Date <= endDate &&
                x.BaseLesson.Cabinet.Number == num)
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
