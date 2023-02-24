using Schedule.Enums;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IUserService
    {
        Task<ICollection<UserInfoDto>> GetUsers(ICollection<Role> roles);
        Task<UserInfoDto> GetUser(Guid id);
        Task UpdateToStudent(Guid id, UserShortInfoDto data);
        Task UpdateToTeacher(Guid id, UserShortInfoDto data);
        Task UpdateToStaff(Guid id, UserShortInfoDto data);
        Task DeleteUser(Guid id);
    }
}
