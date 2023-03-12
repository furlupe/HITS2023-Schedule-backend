using Schedule.Models.DTO;

namespace Schedule.Services.Interfaces
{
    public interface IAuthService
    {
        Task Register(RegistrationDto user);

        Task<TokensDto> MobileLogin(LoginCredentials user);
        Task<TokensDto> WebLogin(LoginCredentials user);

        Task Logout(string token, Guid userId);

        Task<TokensDto> Refresh(string token);
    }
}
