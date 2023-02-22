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
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCredentials credentials) 
        {
            try
            {
                return await _authService.Login(credentials);
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [Authorize(Policy = "NotBlacklisted")]
        [HttpPost("logout")]
        public async Task Logout() =>
            await _authService.Logout(Request.Headers.Authorization);
    }
}
