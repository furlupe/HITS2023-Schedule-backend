using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
{
    public class GroupService: IGroupService
    {
        private readonly ApplicationContext _context;
        public GroupService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<int>> GetAllGroups()
        {
            var response = new List<int>();
            var groups = await _context.Groups.ToListAsync();
            foreach ( var group in groups)
            {
                response.Add(group.Number);
            }
            return response;
        }
        public async Task<List<LessonDTO>> GetSchedule(int num, DateTime start, DateTime end)
        {
            var response = new List<LessonDTO>();
            var thisGroup = await _context.Groups.FirstOrDefaultAsync(x => x.Number == num);
            var lessons = await _context.Lessons.
                Include(cab => cab.Cabinet).
                Include(sub => sub.Subject).
                Include(th => th.Teacher).
                Include(gr => gr.Groups).
                Include(ts => ts.Timeslot).
                Where(x => x.Groups.Contains(thisGroup) && x.Timeslot.StartsAt >= start && x.Timeslot.EndsAt <= end)
                .ToListAsync();
            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Groups)
                {
                    groups.Add(group.Number);
                }

                response.Add(new LessonDTO
                {
                    Subject = lesson.Subject.Name,
                    Cabinet = new CabinetDTO
                    {
                        Number = lesson.Cabinet.Number,
                        Name = lesson.Cabinet.Name
                    },
                    GroupsNum = groups,
                    Teacher = lesson.Teacher.Name,
                    Start = lesson.Timeslot.StartsAt,
                    End = lesson.Timeslot.EndsAt
                });
            }
            return response;
        }
    }
}
