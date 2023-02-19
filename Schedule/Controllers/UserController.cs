using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("account")]
    public class UserController : ControllerBase
    {
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
