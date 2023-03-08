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
    [Route("groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<ActionResult<List<int>>> GetAllGroups()
        {
            return Ok(await _groupService.GetAllGroups());
        }

        [HttpGet("me/schedule")]
        [RoleAuthorization(RoleEnum.STUDENT | RoleEnum.TEACHER)]
        [Authorize(Policy = "NotBlacklisted")]
        public async Task<ActionResult<List<LessonDTO>>> GetUserSchedule(
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return Ok(await _groupService.GetUserSchedule(userId, startsAt, endsAt));
        }
        [HttpGet("{num}/schedule")]
        public async Task<ActionResult<List<LessonDTO>>> GetGroupSchedule(
            [BindRequired] int num,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _groupService.GetSchedule(num, startsAt, endsAt));
        }
    }
}
