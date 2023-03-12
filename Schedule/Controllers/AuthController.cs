using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
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

        [HttpPost("refresh")]
        public async Task<ActionResult<TokensDto>> Refresh([FromQuery, BindRequired] string token)
            => Ok(await _authService.Refresh(token));

        [HttpPost("register")]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.ROOT)]
        public async Task<IActionResult> Register(RegistrationDto user)
        {
            var roleClaims = User.Claims.Where(c => c.Type == ClaimTypes.Role);
            var senderRoles = new List<RoleEnum>();
            foreach (var role in roleClaims)
            {
                Enum.TryParse(role.Value, out RoleEnum sendByRole);
                senderRoles.Add(sendByRole);
            }

            if (user.Roles.Any(r => r == RoleEnum.ROOT))
            {
                throw new BadHttpRequestException(ErrorStrings.ROOT_GIVEN_ERROR);
            }

            if (user.Roles.Any(r => r == RoleEnum.ADMIN) && !senderRoles.Contains(RoleEnum.ROOT))
            {
                throw new BadHttpRequestException(
                    ErrorStrings.ACCESS_DENIED_ERROR,
                    StatusCodes.Status403Forbidden
                    );
            }

            await _authService.Register(user);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPost("login/mobile")]
        public async Task<ActionResult<TokensDto>> MobileLogin(LoginCredentials credentials)
            => Ok(await _authService.MobileLogin(credentials));

        [HttpPost("login/web")]
        public async Task<ActionResult<TokensDto>> WebLogin(LoginCredentials credentials)
            => Ok(await _authService.WebLogin(credentials));

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            await _authService.Logout(Request.Headers.Authorization, userId);
            return Ok();
        }
    }
}
