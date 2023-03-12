using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ICabinetService
    {
        Task<CabinetListDto> GetAllCabinets();
        Task<LessonListDto> GetSchedule(int num, DateTime start, DateTime ends);
        Task AddCabinet(CabinetDTO cabinet);
        Task DeleteCabinet(int number);
    }
}
