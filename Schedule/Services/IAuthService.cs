using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task RegisterStudent(RegistrationDto user);
        Task RegisterTeacher(RegistrationDto user);
        Task RegisterStaff(RegistrationDto user);

        Task<JsonResult> MobileLogin(LoginCredentials user);
        Task<JsonResult> WebLogin(LoginCredentials user);

        Task Logout(string token);
    }
}
