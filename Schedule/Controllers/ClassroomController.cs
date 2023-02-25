using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("classrooms")]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomService _classroomService;

        public ClassroomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }
        [HttpGet]
        public async Task<ActionResult<ClassroomListDTO>> GetAllClasrooms()
        {
            return Ok(await _classroomService.GetAllClassroom());
        }

        [HttpGet("{number}/schedule")]
        public async Task<ActionResult<ScheduleDTO>> GetClassroomSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _classroomService.GetSchedule(number, startsAt, endsAt));
        }
    }
}
