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
            var confir = await _context.Groups.FirstOrDefaultAsync(c => c.Number == num);
            if (confir == null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.GROUP_WRONG_ID_ERROR, num),
                    StatusCodes.Status404NotFound);
            }
            var thisGroup = await _context.Groups.FirstOrDefaultAsync(x => x.Number == num);
            var startDate = DateOnly.FromDateTime(start);
            var endDate = DateOnly.FromDateTime(end);
            var response = new List<LessonDTO>();
            var lessons = await _context.ScheduledLessons.
                Include(x => x.Lesson).ThenInclude(cab => cab.Cabinet).
                Include(x => x.Lesson).ThenInclude(sub => sub.Subject).
                Include(x => x.Lesson).ThenInclude(th => th.Teacher).
                Include(x => x.Lesson).ThenInclude(gr => gr.Groups).
                Include(x => x.Lesson).ThenInclude(ts => ts.Timeslot).
                Where(x => x.Date >= startDate &&
                x.Date <= endDate &&
                x.Lesson.Groups.Contains(thisGroup))
                .ToListAsync();

            foreach (var lesson in lessons)
            {
                List<int> groups = new List<int>();
                foreach (var group in lesson.Lesson.Groups)
                {
                    groups.Add(group.Number);
                }

                var dateReplacemnt = new DateOnly();
                response.Add(new LessonDTO
                {
                    Type = Convert.ToInt32(lesson.Lesson.Type),
                    Subject = lesson.Lesson.Subject.Name,
                    Cabinet = new CabinetDTO
                    {
                        Number = lesson.Lesson.Cabinet.Number,
                        Name = lesson.Lesson.Cabinet.Name
                    },
                    Teacher = lesson.Lesson.Teacher.Name,
                    Timeslot = new TimeslotDTO
                    {
                        startAt =  dateReplacemnt.ToDateTime(lesson.Lesson.Timeslot.StartsAt),
                        endsAt = dateReplacemnt.ToDateTime(lesson.Lesson.Timeslot.EndsAt)
                    },
                    GroupsNum = groups,
                    Date = lesson.Date
                });
            }
            return response;
        }
    }
}
