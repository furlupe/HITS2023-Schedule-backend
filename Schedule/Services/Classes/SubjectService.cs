using Microsoft.EntityFrameworkCore;
using Schedule.Models;
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

        public async Task AddSubject(SubjectShortDto subject)
        {
            await _context.Subjects.AddAsync(new Subject
            {
                Name = subject.Name
            });
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubject(Guid id)
        {
            await _context.Subjects.Where(s => s.Id == id).ExecuteDeleteAsync();
        }

        public async Task<SubjectListDto> GetSubjects()
        {
            var response = new List<SubjectDto>();
            var subjects = await _context.Subjects.ToListAsync();
            foreach (var subject in subjects)
            {
                response.Add(new SubjectDto { Id = subject.Id, Name = subject.Name });
            }
            return new SubjectListDto { Subjects = response };
        }
    }
}
