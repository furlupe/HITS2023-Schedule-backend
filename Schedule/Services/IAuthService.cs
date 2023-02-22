using Microsoft.AspNetCore.Mvc;
using Schedule.Enums;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task RegisterStudent(RegistrationDTO user);
        Task RegisterTeacher(RegistrationDTO user);
        Task RegisterStaff(RegistrationDTO user);

        Task<JsonResult> MobileLogin(LoginCredentials user);
        Task<JsonResult> WebLogin(LoginCredentials user);
        Task Logout(string token);
    }
}
