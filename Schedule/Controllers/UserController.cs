using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Exceptions;
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
        public async Task<ActionResult<ICollection<UserInfoDto>>> GetListOfUsers([FromQuery(Name = "role")] ICollection<Role> roles)
        {
            return Ok(await _userService.GetUsers(roles));
        }

        [HttpGet("me")]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<UserShortInfoDto>> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return await GetUser(userId);
        }

        [HttpGet("{id}")]
        [RoleAuthorization(Role.ADMIN | Role.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<UserShortInfoDto>> GetUser([BindRequired] Guid id)
        {
            try
            {
                return Ok(await _userService.GetUser(id));
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPut("{id}")]
        [RoleAuthorization(Role.ADMIN | Role.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> UpdateUser(UserShortInfoDto data, [BindRequired] Guid id)
        {
            var roleClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);
            Enum.TryParse(roleClaim.Value, out Role sendByRole);

            try
            {
                switch (data.Role)
                {
                    case Role.STUDENT: await _userService.UpdateToStudent(id, data); break;
                    case Role.TEACHER: await _userService.UpdateToTeacher(id, data); break;
                    case Role.EDITOR: await _userService.UpdateToStaff(id, data); break;
                    case Role.ADMIN:
                        {
                            if (sendByRole is not Role.ROOT)
                            {
                                throw new BadHttpRequestException(ErrorStrings.NOT_A_ROOT_ERROR);
                            }
                            await _userService.UpdateToStaff(id, data); break;
                        }
                    case Role.ROOT: throw new ForbiddenException();
                    default: throw new BadHttpRequestException("", 500);
                }

                return Ok();
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
            catch (ForbiddenException)
            {
                return StatusCode(StatusCodes.Status403Forbidden);
            }
            catch (InternalServerException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        [RoleAuthorization(Role.ADMIN | Role.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<IActionResult> DeleteUser([BindRequired] Guid id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch (BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
