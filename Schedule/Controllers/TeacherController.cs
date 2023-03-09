using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
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
        [Authorize(Policy = "NotBlacklisted")]
        [RoleAuthorization(RoleEnum.TEACHER | RoleEnum.STUDENT)]
        public async Task<ActionResult<LessonListDto>> GetUserSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return Ok(await _teacherService.GetSchedule(userId, startsAt, endsAt));
        }

        [HttpGet("{id}")]
        [Authorize(Policy = "NotBlackListed")]
        [RoleAuthorization(RoleEnum.TEACHER)]
        public async Task<ActionResult<string>> GetName([BindRequired] Guid id)
        {
            return Ok(await _teacherService.GetName(id));
        }

        [HttpGet("{id}/schedule")]
        public async Task<ActionResult<LessonListDto>> GetTeacherSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _teacherService.GetSchedule(id, startsAt, endsAt));
        }

    }
}
