using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
                var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
                Enum.TryParse(roleClaim.Value, out Role sendByRole);

                switch (user.Role)
                {
                    case Role.STUDENT: await _authService.RegisterStudent(user); break;
                    case Role.TEACHER: await _authService.RegisterTeacher(user); break;
                    case Role.EDITOR: await _authService.RegisterStaff(user); break;
                    case Role.ADMIN:
                        {
                            if (sendByRole is not Role.ROOT)
                            {
                                throw new BadHttpRequestException(ErrorStrings.NOT_A_ROOT_ERROR, StatusCodes.Status403Forbidden);
                            }
                            await _authService.RegisterStaff(user);
                            break;
                        }
                    case Role.ROOT: throw new BadHttpRequestException(ErrorStrings.ROOT_GIVEN_ERROR, StatusCodes.Status403Forbidden);
                    default: throw new BadHttpRequestException("", 500);
                }

                return Ok();
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        [HttpPost("login/mobile")]
        public async Task<IActionResult> MobileLogin(LoginCredentials credentials)
        {
            try
            {
                return await _authService.MobileLogin(credentials);
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        [HttpPost("login/web")]
        public async Task<IActionResult> WebLogin(LoginCredentials credentials)
        {
            try
            {
                return await _authService.WebLogin(credentials);
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        [Authorize(Policy = "NotBlacklisted")]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout(Request.Headers.Authorization);
            return Ok();
        }
    }
}
