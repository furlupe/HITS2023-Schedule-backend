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
        public async Task<ICollection<UserInfoDto>> GetUsers(ICollection<Role> roles)
        {
            var selectedUsers = new List<User>();
            if (roles.Count > 0)
            {
                selectedUsers = await _context.Users
                    .Where(u => roles.Contains(u.Role))
                    .ToListAsync();
            }
            else
            {
                selectedUsers = await _context.Users.ToListAsync();
            }

            var users = new List<UserInfoDto>();
            foreach (var user in selectedUsers)
            {
                users.Add(new UserInfoDto
                {
                    Id = user.Id,
                    Login = user.Login,
                    Role = user.Role,
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
                Role = user.Role,
                TeacherId = (user.TeacherProfile is null) ? null : user.TeacherProfile.Id,
                Group = (user.Group is null) ? null : user.Group.Number
            };
        }
        public async Task UpdateToStudent(Guid id, UserShortInfoDto data)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Number == data.Group);
            if (group is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.GROUP_WRONG_NUMBER_ERROR, data.Group)
                    );
            }

            await UpdateUser(id, new UserUpdateObject
            {
                Role = data.Role,
                Teacher = null,
                Group = group
            });
        }
        public async Task UpdateToTeacher(Guid id, UserShortInfoDto data)
        {
            var t = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == data.TeacherId);
            if (t is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_WRONG_ID_ERROR, data.TeacherId)
                    );
            }

            if (await _context.Users.AnyAsync(u => u.TeacherProfile == t))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR, t.Id)
                    );
            }

            await UpdateUser(id, new UserUpdateObject
            {
                Role = data.Role,
                Teacher = t,
                Group = null
            });
        }
        public async Task UpdateToStaff(Guid id, UserShortInfoDto data)
        {
            await UpdateUser(id, new UserUpdateObject
            {
                Role = data.Role,
                Teacher = null,
                Group = null
            });
        }
        private async Task UpdateUser(Guid id, UserUpdateObject data)
        {
            var user = await AccessUser(id);

            user.Role = data.Role;
            user.Group = data.Group;
            user.TeacherProfile = data.Teacher;

            await _context.SaveChangesAsync();
        }
        private async Task<User> AccessUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.TeacherProfile)
                .Include(u => u.Group)
                .SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.USER_WRONG_ID_ERROR, id));
            }

            return user;
        }
    }
}
