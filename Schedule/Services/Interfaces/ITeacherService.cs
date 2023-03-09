using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<TeacherListDto> GetAllTeachers();
        Task<LessonListDto> GetSchedule(Guid id, DateTime start, DateTime end);
        Task<LessonListDto> GetUserSchedule(Guid id, DateTime start, DateTime end);
    }
}
