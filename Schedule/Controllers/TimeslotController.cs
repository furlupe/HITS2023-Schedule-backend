using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("timeslots")]
    public class TimeslotController : Controller
    {
        private readonly ITimeslotService _timeslotService;
        public TimeslotController(ITimeslotService timeslotService)
        {
            _timeslotService = timeslotService;
        }

        [HttpGet]
        public async Task<ActionResult<TimeslotListDto>> GetTimeslots()
        {
            return Ok(await _timeslotService.GetTimeslots());
        }
    }
}
