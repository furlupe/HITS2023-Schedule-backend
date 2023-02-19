using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("classrooms")]
    public class ClassroomController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllClasrooms()
        {
            return Ok();
        }

        [HttpGet("{number}/schedule")]
        public IActionResult GetClassroomSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt )
        {
            return Ok();
        }
    }
}
