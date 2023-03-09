using Microsoft.AspNetCore.Mvc;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;

namespace Schedule.Controllers
{
    [ApiController]
    [Route("subjects")]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService groupService)
        {
            _subjectService = groupService;
        }
        [HttpGet]
        public async Task<ActionResult<SubjectListDto>> GetAllGroups()
        {
            return Ok(await _subjectService.GetSubjects());
        }
    }
}