using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("groups")]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllGroups()
        {
            return Ok();
        }

        [HttpGet("{id}/schedule")]
        public IActionResult GetGroupSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok();
        }
    }
}
