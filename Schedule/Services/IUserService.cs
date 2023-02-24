using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IUserService
    {
        Task<UserInfoDto> GetUser(Guid id);
        Task UpdateToStudent(Guid id, UserInfoDto data);
        Task UpdateToTeacher(Guid id, UserInfoDto data);
        Task UpdateToStaff(Guid id, UserInfoDto data);
        Task DeleteUser(Guid id);
    }
}
