using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface ILessonService
    {
        Task CreateLesson(LessonCreateDTO lesson);
        Task EditSingleLesson(SingleLessonEditDto lesson, Guid id);
        Task EditAllLessons(LessonCreateDTO lesson, Guid id);
        Task DeleteLesson(Guid id);
    }
}
