using Schedule.Enums;
using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserListDto> GetUsers(ICollection<RoleEnum> roles);
        Task<UserInfoDto> GetUser(Guid id);
        Task UpdateUser(Guid id, UserShortInfoDto data);
        Task DeleteUser(Guid id, IEnumerable<RoleEnum> senderRoles);
    }
}
