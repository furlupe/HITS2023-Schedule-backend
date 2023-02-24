using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeacherController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTeachers()
        {
            return Ok();
        }

        [HttpGet("{id}/schedule")]
        public IActionResult GetTeacherSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok();
        }

    }
}
