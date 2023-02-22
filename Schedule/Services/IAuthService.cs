using Microsoft.AspNetCore.Mvc;
using Schedule.Enums;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task Register(RegistrationDTO user, Role registeredBy);
        Task<JsonResult> MobileLogin(LoginCredentials user);
        Task<JsonResult> WebLogin(LoginCredentials user);
        Task Logout(string token);
    }
}
