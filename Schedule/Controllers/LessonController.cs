using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

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
        [RoleAuthorization(RoleEnum.EDITOR | RoleEnum.ADMIN | RoleEnum.ROOT)]
        public async Task<IActionResult> CreateLesson(LessonCreateDTO lesson)
        {
            await _lessonService.CreateLesson(lesson);
            return Ok();
        }

        [HttpPut("single/{id}")]
        [RoleAuthorization(RoleEnum.EDITOR | RoleEnum.ADMIN | RoleEnum.ROOT)]
        public async Task<IActionResult> UpdateLesson(SingleLessonEditDto lesson, [BindRequired] Guid id)
        {
            await _lessonService.EditSingleLesson(lesson, id);
            return Ok();
        }

        [HttpPut("all/{id}")]
        [RoleAuthorization(RoleEnum.EDITOR | RoleEnum.ADMIN | RoleEnum.ROOT)]
        public async Task<IActionResult> UpdateLesson(LessonCreateDTO lesson, [BindRequired] Guid id)
        {
            await _lessonService.EditAllLessons(lesson, id);
            return Ok();
        }

        [HttpDelete("{id}")]
        [RoleAuthorization(RoleEnum.EDITOR | RoleEnum.ADMIN | RoleEnum.ROOT)]
        public async Task<IActionResult> RemoveLesson([BindRequired] Guid id)
        {
            await _lessonService.DeleteLesson(id);
            return Ok();
        }
    }
}
