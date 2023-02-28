using Microsoft.EntityFrameworkCore;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Utils;

namespace Schedule.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationContext _context;
        public UserService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task DeleteUser(Guid id)
        {

            _context.Users.Remove(await AccessUser(id));
            await _context.SaveChangesAsync();
        }
        public async Task<ICollection<UserInfoDto>> GetUsers(ICollection<RoleEnum> roles)
        {
            var selectedUsers = await _context.Users
                    .Include(u => u.Roles)
                    .Include(u => u.TeacherProfile)
                    .Include(u => u.Group)
                    .ToListAsync();

            if (roles.Count > 0)
            {
                selectedUsers = selectedUsers.Where(
                    u => u.Roles
                        .Select(r => r.Value)
                        .Intersect(roles)
                        .Any()
                    )
                    .ToList();
            }

            var users = new List<UserInfoDto>();
            foreach (var user in selectedUsers)
            {
                users.Add(new UserInfoDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Roles = user.Roles.Select(r => r.Value).ToList(),
                    TeacherId = user.TeacherProfile is null ? null : user.TeacherProfile.Id,
                    Group = user.Group is null ? null : user.Group.Number
                });
            }

            return users;
        }
        public async Task<UserInfoDto> GetUser(Guid id)
        {
            var user = await AccessUser(id);

            return new UserInfoDto
            {
                Id = user.Id,
                Login = user.Login,
                Roles = user.Roles.Select(r => r.Value).ToList(),
                TeacherId = (user.TeacherProfile is null) ? null : user.TeacherProfile.Id,
                Group = (user.Group is null) ? null : user.Group.Number
            };
        }

        public async Task UpdateUser(Guid id, UserShortInfoDto data)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Number == data.Group);
            if (group is null && data.Roles.Contains(RoleEnum.STUDENT))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.GROUP_WRONG_NUMBER_ERROR, data.Group),
                    StatusCodes.Status404NotFound
                    );
            }

            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == data.TeacherId);
            if (teacher is null && data.Roles.Contains(RoleEnum.TEACHER))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_WRONG_ID_ERROR, data.TeacherId),
                    StatusCodes.Status404NotFound
                    );
            }

            if (teacher is not null && await _context.Users.AnyAsync(u => u.TeacherProfile == teacher))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR, teacher.Id),
                    StatusCodes.Status409Conflict);
            }

            var user = await AccessUser(id);

            user.Roles = await _context.Roles.Where(r => data.Roles.Contains(r.Value)).ToListAsync();
            user.Group = group;
            user.TeacherProfile = teacher;

            await _context.SaveChangesAsync();
        }
        private async Task<User> AccessUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.TeacherProfile)
                .Include(u => u.Group)
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Id == id);

            if (user.Roles.Any(r => r.Value == RoleEnum.ROOT))
            {
                throw new BadHttpRequestException(ErrorStrings.ACCESS_DENIED);
            }

            if (user is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.USER_WRONG_ID_ERROR, id),
                    StatusCodes.Status404NotFound
                    );
            }

            return user;
        }
    }
}
