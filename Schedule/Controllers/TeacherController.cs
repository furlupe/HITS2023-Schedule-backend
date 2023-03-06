using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models.DTO;
using Schedule.Services;

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
        public async Task<ActionResult<List<TeacherDTO>>> GetAllTeachers()
        {
            return await _teacherService.GetAllTeachers();
        }

        [HttpGet("{id}/schedule")]
        public async Task<ActionResult<List<LessonDTO>>> GetTeacherSchedule(
            [BindRequired] Guid id,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return await _teacherService.GetSchedule(id, startsAt, endsAt);
        }

    }
}
