using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<List<TeacherDTO>> GetAllTeachers();
        Task<List<LessonDTO>> GetSchedule(Guid id, DateTime start, DateTime end);
        Task<string> GetName(Guid id);
    }
}
