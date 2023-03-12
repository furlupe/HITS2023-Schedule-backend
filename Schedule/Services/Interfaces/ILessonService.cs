using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ILessonService
    {
        Task CreateLesson(LessonCreateDTO lesson);
        Task EditSingleLesson(SingleLessonEditDto lesson, Guid id);
        Task EditAllLessons(LessonCreateDTO lesson, Guid id);
        Task DeleteSingleLesson(Guid id);
        Task DeleteAllLessons(Guid id);
        Task<LessonDTO> GetScheduledLesson(Guid id);
    }
}
