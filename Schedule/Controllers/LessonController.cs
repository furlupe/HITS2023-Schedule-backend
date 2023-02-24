using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("lesson")]
    public class LessonController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateLesson()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLesson()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveLesson([BindRequired] Guid id)
        {
            return Ok();
        }
    }
}
