using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ICabinetService
    {
        Task<List<int>> GetAllCabinets();
        Task<List<LessonDTO>> GetSchedule(int num, DateTime start, DateTime ends);
    }
}
