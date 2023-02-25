using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface ILessonService
    {
        Task CreateLesson(LessonCreateDTO lesson);
    }
}
