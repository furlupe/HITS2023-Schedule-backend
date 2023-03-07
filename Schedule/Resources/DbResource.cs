using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Utils;
using System.Linq;
using System.Net;

namespace Schedule.Resources
{
    public class DbResource : IResource
    {
        private readonly ApplicationContext _context;

        public DbResource(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddLesson(Lesson lesson)
        {
            await _context.Lessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task AddRefreshToken(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();
        }

        public async Task<Cabinet> GetCabinet(int number)
        {
            return await _context.Cabinets.SingleOrDefaultAsync(c => c.Number == number)
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.CABINET_WRONG_ID_ERROR, number)
                    );
        }

        public async Task<ICollection<Group>> GetGroups(ICollection<int> groups)
        {
            var response = await _context.Groups
                .Where(g => groups.Contains(g.Number))
                .ToListAsync();

            var unaddedGroups = groups.Except(response.Select(g => g.Number));
            if (unaddedGroups.Any())
            {
                throw new BadHttpRequestException(
                    string.Format(
                        ErrorStrings.WRONG_GROUPS_ID_ERROR,
                        string.Join(", ", unaddedGroups))
                    );
            }

            return response;
        }

        public async Task<ICollection<Lesson>> GetSimilarLessons(Lesson lesson)
        {
            return await _context.Lessons
                .Where(l =>
                    l.Day == lesson.Day &&
                    l.Cabinet == lesson.Cabinet &&
                    l.Timeslot == lesson.Timeslot)
                .ToListAsync();
        }

        public async Task<Subject> GetSubject(Guid id)
        {
            return await _context.Subjects.SingleOrDefaultAsync(s => s.Id == id)
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.SUBJECT_WRONG_ID_ERROR, id)
                    );
        }

        public async Task<Teacher> GetTeacher(Guid? id)
        {
            return await _context.Teachers.SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_WRONG_ID_ERROR, id)
                    );
        }

        public async Task<Timeslot> GetTimeslot(Guid id)
        {
            return await _context.Timeslots.SingleOrDefaultAsync(t => t.Id == id)
                ?? throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TIMESLOT_WRONG_ID_ERROR, id)
                    );
        }

        public async Task<User> GetUserByCredentials(string login, string password)
        {
            return await _context.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Login == login && u.Password == password)
                ?? throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
        }

        public async Task<RefreshToken?> GetRefreshTokenByUser(User user)
        {
            return await _context.RefreshTokens
                .SingleOrDefaultAsync(u => u.User == user);
        }

        public async Task ScheduleLesson(LessonScheduled lesson)
        {
            await _context.ScheduledLessons.AddAsync(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task AddBlacklistedToken(BlacklistedToken token)
        {
            await _context.Blacklist.AddAsync(token);
            await _context.SaveChangesAsync();
        }

        public async Task<Group?> GetGroup(int? number)
        {
            return await _context.Groups.SingleOrDefaultAsync(g => g.Number == number);
        }

        public async Task<bool> DoesTeacherAccountExist(Teacher teacher)
        {
            return await _context.Users.AnyAsync(u => u.TeacherProfile == teacher);
        }

        public async Task<bool> IsLoginTaken(string login)
        {
            return await _context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task<ICollection<Role>> GetRoles(ICollection<RoleEnum> roles)
        {
            return await _context.Roles.Where(r => roles.Contains(r.Value)).ToListAsync();
        }

        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetRefreshToken(string refreshToken)
        {
            return await _context.RefreshTokens
                .Include(t => t.User)
                    .ThenInclude(u => u.Roles)
                .SingleOrDefaultAsync(t => t.Value == refreshToken)
                ?? throw new BadHttpRequestException(
                    string.Empty, 
                    StatusCodes.Status401Unauthorized);
        }

        public async Task RemoveRefreshToken(RefreshToken refreshToken)
        {
            _context.RefreshTokens.Remove(refreshToken);
            await _context.SaveChangesAsync();
        }
    }
}
