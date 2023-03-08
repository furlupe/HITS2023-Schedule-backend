using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationContext _context;
        public SubjectService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ICollection<SubjectDto>> GetSubjects()
        {
            var response = new List<SubjectDto>();
            var subjects = await _context.Subjects.ToListAsync();
            foreach (var subject in subjects)
            {
                response.Add(new SubjectDto { Id = subject.Id, Name = subject.Name });
            }
            return response;
        }
    }
}
