using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services;
using Schedule.Utils;
using System.Security.Claims;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
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

        // TODO: create DTO for user changed info
        [HttpPut("{id}")]
        [RoleAuthorization(Role.ADMIN | Role.ROOT)]
        [Authorize(Policy = "NotBlacklisted")]
        public IActionResult UpdateUser([BindRequired] Guid id)
        {
            return Ok();
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
