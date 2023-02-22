using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task Register(RegistrationDTO user);
        Task RegisterStudent(StudentRegistrationDTO student);
        Task RegisterTeacher(TeacherRegistrationDTO teacher);
        Task<JsonResult> Login(LoginCredentials user);
        Task Logout(string token);
    }
}
