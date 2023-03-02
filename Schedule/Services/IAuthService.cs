using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task Register(RegistrationDto user);

        Task<TokensDto> MobileLogin(LoginCredentials user);
        Task<TokensDto> WebLogin(LoginCredentials user);

        Task Logout(string token);

        Task<TokensDto> Refresh(string token);
    }
}
