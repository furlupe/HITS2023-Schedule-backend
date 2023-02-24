using Microsoft.EntityFrameworkCore;
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
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.USER_WRONG_ID_ERROR, id));
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task<UserShortInfoDto> GetUser(Guid id)
        {
            var user = await _context.Users
                .Include(u => u.TeacherProfile)
                .Include(u => u.Group)
                .SingleOrDefaultAsync(u => u.Id == id);

            if (user is null)
            {
                throw new BadHttpRequestException(string.Format(ErrorStrings.USER_WRONG_ID_ERROR, id));
            }

            return new UserShortInfoDto
            {
                Role = user.Role,
                TeacherId = (user.TeacherProfile is null) ? null : user.TeacherProfile.Id,
                Group = (user.Group is null) ? null : user.Group.Number
            };
        }

        public Task UpdateUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
