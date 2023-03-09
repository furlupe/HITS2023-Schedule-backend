using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectListDto> GetSubjects();
    }
}
