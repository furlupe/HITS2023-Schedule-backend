using Schedule.Models;
using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface IEntityScheduleService
    {
        LessonListDto CreateLessonResponse(ICollection<LessonScheduled> lessons);
        LessonDTO CreateSingleLessonResponse(LessonScheduled lesson);
    }
}
