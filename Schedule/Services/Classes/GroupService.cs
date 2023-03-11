using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationContext _context;
        private readonly IEntityScheduleService _educationalEntityService;
        public GroupService(ApplicationContext context, IEntityScheduleService educationalEntityService)
        {
            _context = context;
            _educationalEntityService = educationalEntityService;
        }
        public async Task<GroupListDto> GetAllGroups()
        {
            var response = new List<int>();
            var groups = await _context.Groups.ToListAsync();
            foreach (var group in groups)
            {
                response.Add(group.Number);
            }
            return new GroupListDto { Groups = response };
        }
        public async Task<LessonListDto> GetSchedule(int num, DateTime start, DateTime end)
        {
            var thisGroup = await _context.Groups.FirstOrDefaultAsync(c => c.Number == num) 
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.GROUP_WRONG_ID_ERROR, num),
                    StatusCodes.Status404NotFound
                );

            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);

            var lessons = await _context.ScheduledLessons.
                Include(x => x.BaseLesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.BaseLesson).ThenInclude(sub => sub.Subject).
                Include(x => x.BaseLesson).ThenInclude(th => th.Teacher).
                Include(x => x.BaseLesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Timeslot).
                Where(x => x.Date >= startDate &&
                    x.Date <= endDate &&
                    x.BaseLesson.Groups.Contains(thisGroup))
                .ToListAsync();

            return _educationalEntityService.CreateLessonResponse(lessons);
        }

        public async Task<LessonListDto> GetUserSchedule(Guid userId, DateTime start, DateTime end)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == userId);
            return await GetSchedule(user.Group.Number, start, end);
        }
    }
}
