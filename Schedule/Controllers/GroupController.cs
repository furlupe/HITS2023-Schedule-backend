using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models.DTO;
using Schedule.Services;

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
            return await _groupService.GetAllGroups();
        }

        [HttpGet("{id}/schedule")]
        public async Task<ActionResult<List<LessonDTO>>> GetGroupSchedule(
            [BindRequired] int num,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return await _groupService.GetSchedule(num, startsAt, endsAt);
        }
    }
}
