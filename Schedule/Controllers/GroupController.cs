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
    [Route("groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }
        [HttpGet]
        public async Task<ActionResult<GroupListDto>> GetAllGroups()
        {
            return Ok(await _groupService.GetAllGroups());
        }

        [HttpGet("me/schedule")]
        [RoleAuthorization(RoleEnum.STUDENT | RoleEnum.TEACHER)]
        public async Task<ActionResult<LessonListDto>> GetUserSchedule(
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);
            Guid.TryParse(userIdClaim.Value, out Guid userId);

            return Ok(await _groupService.GetUserSchedule(userId, startsAt, endsAt));
        }
        [HttpGet("{number}/schedule")]
        public async Task<ActionResult<LessonListDto>> GetGroupSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _groupService.GetSchedule(number, startsAt, endsAt));
        }

        [HttpPost]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.ROOT)]
        public async Task<IActionResult> AddGroup(GroupDto group)
        {
            await _groupService.AddGroup(group);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
