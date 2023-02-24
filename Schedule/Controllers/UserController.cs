using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services;
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
        public async Task<ActionResult<UserShortInfoDto>> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            Guid.TryParse(userIdClaim.Value, out Guid userId);

            try
            {
                return Ok(await _userService.GetUser(userId));
            }
            catch(BadHttpRequestException e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserShortInfoDto>> GetUser([BindRequired] Guid id)
        {
            return Ok(await _userService.GetUser(id));
        }

        // TODO: create DTO for user changed info
        [HttpPut("{id}")]
        public IActionResult UpdateUser([BindRequired] Guid id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser([BindRequired] Guid id) 
        {
            return Ok();
        }
    }
}
