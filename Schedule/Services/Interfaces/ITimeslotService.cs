using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ITimeslotService
    {
        Task<ICollection<TimeslotDTO>> GetTimeslots();
    }
}
