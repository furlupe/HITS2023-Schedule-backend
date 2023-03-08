using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IGroupService
    {
        Task<List<int>> GetAllGroups();
        Task<List<LessonDTO>> GetSchedule(int num, DateTime start, DateTime end);
    }
}
