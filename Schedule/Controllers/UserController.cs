using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetUser([BindRequired] Guid id)
        {
            return Ok();
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
