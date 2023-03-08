using Microsoft.EntityFrameworkCore;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Services.Interfaces;
using Schedule.Utils;
using System.Data;

namespace Schedule.Services.Classes
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        private readonly ITokenService _tokenService;
        public AuthService(ApplicationContext context, ITokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }

        public async Task<TokensDto> MobileLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                !user.Roles.Any(r => r.Value == RoleEnum.STUDENT || r.Value == RoleEnum.TEACHER))
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return await Login(user);
        }
        public async Task<TokensDto> WebLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                !user.Roles.Any(r =>
                    r.Value == RoleEnum.ADMIN ||
                    r.Value == RoleEnum.EDITOR ||
                    r.Value == RoleEnum.ROOT)
                )
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return await Login(user);
        }

        public async Task Logout(string token)
        {
            await _context.Blacklist.AddAsync(new BlacklistedToken
            {
                Value = token
            });

            await _context.SaveChangesAsync();
        }

        public async Task Register(RegistrationDTO user)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Number == user.GroupNumber);

            if (user.Roles.Any(r => r == RoleEnum.STUDENT) && group is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.GROUP_WRONG_ID_ERROR, user.GroupNumber)
                    );
            }

            var teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == user.TeacherID);

            if (user.Roles.Any(r => r == RoleEnum.TEACHER) && teacher is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_NO_ID_ERROR, user.TeacherID)
                    );
            }

            if (user.Roles.Any(r => r == RoleEnum.TEACHER) &&
                await _context.Users.AnyAsync(u => u.TeacherProfile == teacher))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR, user.TeacherID)
                    );
            }

            if (await _context.Users.AnyAsync(u => u.Login == user.Login))
            {
                throw new BadHttpRequestException(ErrorStrings.LOGIN_TAKEN_ERROR, StatusCodes.Status409Conflict);
            }

            var roles = await _context.Roles.Where(r => user.Roles.Contains(r.Value)).ToListAsync();

            await _context.Users.AddAsync(new User
            {
                Login = user.Login,
                Password = Credentials.EncodePassword(user.Password),
                Roles = roles,
                TeacherProfile = teacher,
                Group = group
            });

            await _context.SaveChangesAsync();
        }

        public async Task<TokensDto> Refresh(string token)
        {
            var rt = await _context.RefreshTokens
                .Include(t => t.User)
                    .ThenInclude(u => u.Roles)
                .SingleOrDefaultAsync(t => t.Value == token);

            if (rt is null || rt.Expiry < DateTime.UtcNow)
            {
                throw new BadHttpRequestException(string.Empty, StatusCodes.Status401Unauthorized);
            }

            return await Login(rt.User);
        }

        private async Task<User?> GetUserByCredentials(LoginCredentials credentials)
        {
            var hashedPassword = Credentials.EncodePassword(credentials.Password);
            return await _context.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Login == credentials.Login && u.Password == hashedPassword);
        }
        private async Task<TokensDto> Login(User user)
        {
            var refreshToken = _tokenService.CreateRefreshToken();
            var rtUser = await _context.RefreshTokens.SingleOrDefaultAsync(u => u.User == user);

            var response = new TokensDto
            {
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = refreshToken
            };

            if (rtUser is not null)
            {
                _context.RefreshTokens.Remove(rtUser);
            }

            await _context.RefreshTokens.AddAsync(new RefreshToken
            {
                Value = refreshToken,
                User = user,
                Expiry = DateTime.UtcNow.AddDays(60)
            });

            await _context.SaveChangesAsync();

            return response;
        }

    }
}
