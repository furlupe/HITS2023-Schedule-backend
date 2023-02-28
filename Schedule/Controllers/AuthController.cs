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
        [RoleAuthorization(RoleEnum.ADMIN | RoleEnum.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> Register(RegistrationDTO user)
        {   
            try
            {
                var roleClaims = User.Claims.Where(c => c.Type == ClaimTypes.Role);
                var senderRoles = new List<RoleEnum>();
                foreach(var role in roleClaims)
                {
                    Enum.TryParse(role.Value, out RoleEnum sendByRole);
                    senderRoles.Add(sendByRole);
                }

                if(user.Roles.Any(r => r == RoleEnum.ROOT))
                {
                    throw new BadHttpRequestException(ErrorStrings.ROOT_GIVEN_ERROR);
                }

                if(user.Roles.Any(r => r == RoleEnum.ADMIN) && !senderRoles.Contains(RoleEnum.ROOT))
                {
                    throw new BadHttpRequestException(ErrorStrings.NOT_A_ROOT_ERROR);
                }

                await _authService.Register(user);
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
