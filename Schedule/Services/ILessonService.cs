using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface ILessonService
    {
        Task CreateLesson(LessonCreateDTO lesson);
        Task EditLesson(LessonCreateDTO lesson, Guid id);
        Task DeleteLesson(Guid id);
    }
}
