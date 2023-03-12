using Microsoft.AspNetCore.Authorization;
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
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.EDITOR, RoleEnum.ROOT)]
        public async Task<IActionResult> CreateLesson(LessonCreateDTO lesson)
        {
            await _lessonService.CreateLesson(lesson);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("single/{id}")]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.EDITOR, RoleEnum.ROOT)]
        public async Task<IActionResult> UpdateLesson(SingleLessonEditDto lesson, [BindRequired] Guid id)
        {
            await _lessonService.EditSingleLesson(lesson, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpPut("all/{id}")]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.EDITOR, RoleEnum.ROOT)]
        public async Task<IActionResult> UpdateLesson(LessonCreateDTO lesson, [BindRequired] Guid id)
        {
            await _lessonService.EditAllLessons(lesson, id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("single/{id}")]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.EDITOR, RoleEnum.ROOT)]
        public async Task<IActionResult> RemoveSingleLesson([BindRequired] Guid id)
        {
            await _lessonService.DeleteSingleLesson(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        [HttpDelete("all/{id}")]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.EDITOR, RoleEnum.ROOT)]
        public async Task<IActionResult> RemoveAllLesson([BindRequired] Guid id)
        {
            await _lessonService.DeleteAllLessons(id);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
