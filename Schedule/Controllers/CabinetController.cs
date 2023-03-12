using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Controllers
{
    // not working rn, service is disabled
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
        public async Task<ActionResult<CabinetListDto>> GetAllCabinets()
        {
            return Ok(await _cabinetService.GetAllCabinets());
        }

        [HttpGet("{number}/schedule")]
        public async Task<ActionResult<LessonListDto>> GetCabinetSchedule(
            [BindRequired] int number,
            [BindRequired] DateTime startsAt,
            [BindRequired] DateTime endsAt)
        {
            return Ok(await _cabinetService.GetSchedule(number, startsAt, endsAt));
        }

        [HttpPost]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.ROOT)]
        public async Task<IActionResult> AddCabinet(CabinetDTO cabinet)
        {
            await _cabinetService.AddCabinet(cabinet);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
