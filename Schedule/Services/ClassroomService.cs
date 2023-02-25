using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
{
    public class ClassroomService : IClassroomService
    {
        private readonly ApplicationContext _context;
        
        public ClassroomService(ApplicationContext context) 
        {
            _context = context; 
        }

        public async Task<ClassroomListDTO> GetAllClassroom()
        {
            var response = new ClassroomListDTO();
            var classroomsModel = _context.Cabinets.ToList();
            foreach (var classroom in classroomsModel) 
            {
                response.Classrooms.Add(classroom.Name);
            }
            return response;
        }
    }
}
