using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services.Classes;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using System.Security.Claims;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet]
        public async Task<ActionResult<TeacherListDto>> GetAllTeachers()
        {
            return Ok(await _teacherService.GetAllTeachers());
        }

        [HttpGet("me/schedule")]
        [RoleAuthorization(RoleEnum.TEACHER, RoleEnum.STUDENT)]
        public async Task<ActionResult<LessonListDto>> GetUserSchedule(
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return Ok(await _teacherService.GetSchedule(userId, startsAt, endsAt));
        }

        [HttpGet("{id}/schedule")]
        public async Task<ActionResult<LessonListDto>> GetTeacherSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _teacherService.GetSchedule(id, startsAt, endsAt));
        }

        [HttpPost]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.ROOT)]
        public async Task<IActionResult> AddTeacher(TeacherShortDto teacher)
        {
            await _teacherService.AddTeacher(teacher);
            return StatusCode(StatusCodes.Status204NoContent);
        }

    }
}
