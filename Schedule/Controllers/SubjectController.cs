using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Schedule.Enums;
using Schedule.Models.DTO;
using Schedule.Services.Classes;
using Schedule.Services.Interfaces;
using Schedule.Utils;

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

        [HttpPost]
        [RoleAuthorization(RoleEnum.ADMIN, RoleEnum.ROOT)]
        public async Task<IActionResult> AddSubject(SubjectShortDto subject)
        {
            await _subjectService.AddSubject(subject);
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}