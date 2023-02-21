﻿using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;

namespace Schedule.Services
{
    public interface IAuthService
    {
        Task Register(RegistrationDTO user);
        Task RegisterStudent(StudentRegistrationDTO student);
        Task RegisterTeacher(TeacherRegistrationDTO teacher);
        Task<JsonResult> MobileLogin(LoginCredentials user);
        Task<JsonResult> WebLogin(LoginCredentials user);
        Task Logout(string token);
    }
}
