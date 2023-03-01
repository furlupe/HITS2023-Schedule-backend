using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Schedule.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        public AuthService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<JsonResult> MobileLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                !user.Roles.Any(r => r.Value == RoleEnum.STUDENT || r.Value == RoleEnum.TEACHER))
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return CreateToken(user);
        }
        public async Task<JsonResult> WebLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                user.Roles.Any(r => r.Value == RoleEnum.STUDENT || r.Value == RoleEnum.TEACHER))
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return CreateToken(user);
        }
        public async Task Logout(string token)
        {
            await _context.Blacklist.AddAsync(new BlacklistedToken
            {
                Value = token
            });

            await _context.SaveChangesAsync();
        }
        public async Task Register(RegistrationDto user)
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
                throw new BadHttpRequestException(
                    ErrorStrings.LOGIN_TAKEN_ERROR, 
                    StatusCodes.Status409Conflict);
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

        private async Task<User?> GetUserByCredentials(LoginCredentials credentials)
        {
            var hashedPassword = Credentials.EncodePassword(credentials.Password);
            return await _context.Users
                .Include(u => u.Roles)
                .SingleOrDefaultAsync(u => u.Login == credentials.Login && u.Password == hashedPassword);
        }
        private JsonResult CreateToken(User user)
        {
            ClaimsIdentity? identity = GetIdentity(user);
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: JwtConfigurations.Issuer,
                audience: JwtConfigurations.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.AddMinutes(JwtConfigurations.Lifetime),
                signingCredentials: new SigningCredentials(JwtConfigurations.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var enctoken = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                token = enctoken
            };

            return new JsonResult(response);
        }
        private ClaimsIdentity GetIdentity(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            foreach(var role in user.Roles.Select(r => r.Value))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            return new ClaimsIdentity(claims, "Token");
        }

    }
}
