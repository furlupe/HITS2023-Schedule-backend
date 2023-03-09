using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupListDto> GetAllGroups();
        Task<LessonListDto> GetSchedule(int num, DateTime start, DateTime end);
        Task<LessonListDto> GetUserSchedule(Guid userId, DateTime start, DateTime end);
    }
}
