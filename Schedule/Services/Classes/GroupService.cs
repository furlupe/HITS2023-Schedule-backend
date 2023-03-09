using Microsoft.EntityFrameworkCore;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;

namespace Schedule.Services.Classes
{
    public class GroupService : IGroupService
    {
        private readonly ApplicationContext _context;
        public GroupService(ApplicationContext context)
        {
            _context = context;
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
            var confir = await _context.Groups.FirstOrDefaultAsync(c => c.Number == num) 
                ?? throw new BadHttpRequestException(
                    string.Format(
                        ErrorStrings.GROUP_WRONG_ID_ERROR, num),
                        StatusCodes.Status404NotFound
                        );

            var thisGroup = await _context.Groups.FirstOrDefaultAsync(x => x.Number == num);
            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);

            var response = new List<LessonDTO>();

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

            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.BaseLesson.Groups)
                {
                    groups.Add(group.Number);
                }

                var dateReplacemnt = new DateOnly();
                response.Add(new LessonDTO
                {
                    Id = lesson.Id,
                    Lesson = new LessonShortDto
                    {
                        Id = lesson.BaseLesson.Id,
                        Teacher = lesson.BaseLesson.Teacher.Name,
                        Subject = lesson.BaseLesson.Subject.Name,
                        Groups = groups,
                        Type = lesson.BaseLesson.Type,
                        Cabinet = new CabinetDTO
                        {
                            Name = lesson.BaseLesson.Cabinet.Name,
                            Number = lesson.BaseLesson.Cabinet.Number
                        }
                    },
                    Timeslot = new TimeslotDTO
                    {
                        Id = lesson.Timeslot.Id,
                        startAt = dateReplacemnt.ToDateTime(lesson.Timeslot.StartsAt),
                        endsAt = dateReplacemnt.ToDateTime(lesson.Timeslot.EndsAt)
                    },
                    Date = lesson.Date.ToDateTime(new TimeOnly(0, 0))
                });
            }
            return new LessonListDto { Lessons = response };
        }

        public async Task<LessonListDto> GetUserSchedule(Guid userId, DateTime start, DateTime end)
        {
            var user = await _context.Users.SingleAsync(u => u.Id == userId);
            return await GetSchedule(user.Group.Number, start, end);
        }
    }
}
