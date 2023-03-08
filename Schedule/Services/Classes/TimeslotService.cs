using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class TimeslotService : ITimeslotService
    {
        private readonly ApplicationContext _context;
        public TimeslotService(ApplicationContext applicationContext)
        {
            _context = applicationContext;
        }
        public async Task<ICollection<TimeslotDTO>> GetTimeslots()
        {
            var response = new List<TimeslotDTO>();
            var timeslots = await _context.Timeslots.ToListAsync();
            var dateReplacement = new DateOnly();
            foreach (var t in timeslots)
            {
                response.Add(new TimeslotDTO
                {
                    Id = t.Id,
                    startAt = dateReplacement.ToDateTime(t.StartsAt),
                    endsAt = dateReplacement.ToDateTime(t.EndsAt)
                });
            }
            return response;
        }
    }
}
