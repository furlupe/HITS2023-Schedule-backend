using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class CabinetService : ICabinetService
    {
        private readonly ApplicationContext _context;
        private readonly IEntityScheduleService _educationalEntityService;

        public CabinetService(ApplicationContext context, IEntityScheduleService educationalEntityService)
        {
            _context = context;
            _educationalEntityService = educationalEntityService;
        }

        public async Task<CabinetListDto> GetAllCabinets()
        {
            var cabinets = new List<CabinetDTO>();
            var cabinetModel = await _context.Cabinets.ToListAsync();
            foreach (var cabinet in cabinetModel)
            {
                cabinets.Add(new CabinetDTO
                {
                    Name = cabinet.Name,
                    Number = cabinet.Number
                });
            }
            return new CabinetListDto { Cabinets = cabinets };
        }

        public async Task<LessonListDto> GetSchedule(int num, DateTime starts, DateTime ends)
        {
            var confir = await _context.Cabinets.FirstOrDefaultAsync(c => c.Number == num)
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.CABINET_WRONG_ID_ERROR, num),
                    StatusCodes.Status404NotFound
                );

            var startDate = DateOnly.FromDateTime(starts);
            var endDate = DateOnly.FromDateTime(ends);

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

            return _educationalEntityService.CreateLessonResponse(lessons);
        }
    }
}
