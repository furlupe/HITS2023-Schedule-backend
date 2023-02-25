using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("lesson")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateLesson(LessonCreateDTO lesson)
        {
            _lessonService.CreateLesson(lesson);
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
