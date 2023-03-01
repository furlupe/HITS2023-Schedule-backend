using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Models.DTO;
using Schedule.Services;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("cabinets")]
    public class CabinetController : ControllerBase
    {
        private readonly ICabinetService _cabinetService;

        public CabinetController(ICabinetService CabinetService)
        {
            _cabinetService = CabinetService;
        }

        [HttpGet]
        public async Task<ActionResult<List<int>>> GetAllCabinets()
        {
            return Ok(await _cabinetService.GetAllCabinets());
        }

        [HttpGet("{number}/schedule")]
        public async Task<ActionResult<List<LessonDTO>>> GetCabinetSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _cabinetService.GetSchedule(number, startsAt, endsAt));
        }
    }
}
