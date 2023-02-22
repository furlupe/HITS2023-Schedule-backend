using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Models;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services;
using Schedule.Utils;
using System.Security.Claims;

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
        [RoleAuthorization(Role.ADMIN | Role.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> Register(RegistrationDTO user) 
        {
            try
            {
                var roleClaim =  User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                Enum.TryParse(roleClaim.Value, out Role role);

                await _authService.Register(user, role);
                return Ok();
            }
            catch (BadHttpRequestException e) 
            {
                return BadRequest(new {error = e.Message});
            }
        }

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
