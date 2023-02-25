using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IClassroomService
    {
        Task<ClassroomListDTO> GetAllClassroom();
        Task<ScheduleDTO> GetSchedule(int num, DateTime start, DateTime ends);
    }
}
