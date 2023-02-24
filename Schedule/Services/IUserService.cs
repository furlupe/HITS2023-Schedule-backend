using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IUserService
    {
        Task<UserShortInfoDto> GetUser(Guid id);
        Task UpdateUser(Guid id);
        Task DeleteUser(Guid id);
    }
}
