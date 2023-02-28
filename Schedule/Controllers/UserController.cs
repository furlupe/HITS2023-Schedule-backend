using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Exceptions;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services;
using Schedule.Utils;
using System.Security.Claims;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<ICollection<UserInfoDto>>> GetListOfUsers([FromQuery(Name = "role")] ICollection<RoleEnum> roles)
        {
            return Ok(await _userService.GetUsers(roles));
        }

        [HttpGet("me")]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<UserInfoDto>> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return await GetUser(userId);
        }

        [HttpGet("{id}")]
        [RoleAuthorization(RoleEnum.ADMIN | RoleEnum.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<UserInfoDto>> GetUser([BindRequired] Guid id)
        {
            try
            {
                return Ok(await _userService.GetUser(id));
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        [HttpPut("{id}")]
        [RoleAuthorization(RoleEnum.ADMIN)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> UpdateUser([BindRequired] Guid id, UserShortInfoDto data)
        {
            var senderRoles = AccessRoles(User.Claims);

            try
            {
                if (data.Roles.Any(r => r == RoleEnum.ROOT))
                {
                    throw new BadHttpRequestException(ErrorStrings.ACCESS_DENIED);
                }

                if (data.Roles.Any(r => r == RoleEnum.ADMIN) 
                    && !senderRoles.Contains(RoleEnum.ROOT))
                {
                    throw new BadHttpRequestException(ErrorStrings.NOT_A_ROOT_ERROR);
                }

                await _userService.UpdateUser(id, data);
                return Ok();
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        [HttpDelete("{id}")]
        [RoleAuthorization(RoleEnum.ADMIN | RoleEnum.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> DeleteUser([BindRequired] Guid id)
        {
            var senderRoles = AccessRoles(User.Claims);

            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (BadHttpRequestException e)
            {
                return StatusCode(e.StatusCode, new { error = e.Message });
            }
        }

        private List<RoleEnum> AccessRoles(IEnumerable<Claim> claims)
        {
            var roleClaims = claims.Where(c => c.Type == ClaimTypes.Role);
            var senderRoles = new List<RoleEnum>();
            foreach (var role in roleClaims)
            {
                Enum.TryParse(role.Value, out RoleEnum sendByRole);
                senderRoles.Add(sendByRole);
            }

            return senderRoles;
        }
    }
}
