using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;
using Schedule.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegistrationDTO user) { return Ok(); }

        [HttpPost("register/teacher")]
        public IActionResult RegisterTeacher(TeacherRegistrationDTO teacher) { return Ok(); }

        [HttpPost("register/student")]
        public IActionResult RegisterStudent(StudentRegistrationDTO student) { return Ok(); }

        // TODO: create DTO for login creds & token creation
        [HttpPost("login/mobile")]
        public async Task<IActionResult> MobileLogin(LoginCredentials credentials) 
        {
            try
            {
                return await _authService.MobileLogin(credentials);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPost("login/web")]
        public async Task<IActionResult?> WebLogin(LoginCredentials credentials) 
        {
            var token = await _authService.WebLogin(credentials);
            if (token is null)
            {
                return Forbid();
            }

            return token;
        }

        [Authorize(Policy = "NotBlacklisted")]
        [HttpPost("logout")]
        public async Task Logout() =>
            await _authService.Logout(Request.Headers.Authorization);
    }
}
