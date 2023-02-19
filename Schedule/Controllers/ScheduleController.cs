using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("api/schedule")]
    public class ScheduleController : ControllerBase
    {
        [HttpGet("group/{id}")]
        public IActionResult GetGroupSchedule(
            [BindRequired] Guid id, 
            [BindRequired] DateTime startsAt, 
            [BindRequired] DateTime endsAt)
        {
            return Ok();
        }

        [HttpGet("teacher/{id}")]
        public IActionResult GetTeacherSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        { 
            return Ok(); 
        }

        [HttpGet("classroom/{number}")]
        public IActionResult GetClassroomSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok();
        }
    }
}
