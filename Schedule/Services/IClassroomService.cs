using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IClassroomService
    {
        Task<ClassroomListDTO> GetAllClassroom();
        Task<ScheduleDTO> GetChedule(int num, DateTime start, DateTime ends);
    }
}
