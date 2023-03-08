using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface IGroupService
    {
        Task<List<int>> GetAllGroups();
        Task<List<LessonDTO>> GetSchedule(int num, DateTime start, DateTime end);
        Task<List<LessonDTO>> GetUserSchedule(Guid userId, DateTime start, DateTime end);
    }
}
