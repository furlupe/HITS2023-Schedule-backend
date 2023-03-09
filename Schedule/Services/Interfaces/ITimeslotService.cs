using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ITimeslotService
    {
        Task<TimeslotListDto> GetTimeslots();
    }
}
