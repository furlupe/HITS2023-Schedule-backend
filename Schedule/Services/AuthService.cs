using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Schedule.Models;
using Schedule.Utils;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Schedule.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationContext _context;
        public AuthService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task RegisterStudent(RegistrationDTO student)
        {
            var group = await _context.Groups.SingleOrDefaultAsync(g => g.Number == student.GroupNumber);
            if (group is null)
            {
                throw new BadHttpRequestException(ErrorStrings.GROUP_WRONG_ID_ERROR);
            }

            await Register(new User
            {
                Login = student.Login,
                Password = EncodePassword(student.Password),
                Role = student.Role,
                Group = group,
                TeacherProfile = null
            });
        }
        public async Task RegisterTeacher(RegistrationDTO teacher)
        {
            var t = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == teacher.TeacherID);
            if (t is null)
            {
                throw new BadHttpRequestException(ErrorStrings.TEACHER_WRONG_ID_ERROR);
            }

            if (await _context.Users.AnyAsync(u => u.TeacherProfile == t))
            {
                throw new BadHttpRequestException(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR);
            }

            await Register(new User
            {
                Login = teacher.Login,
                Password = EncodePassword(teacher.Password),
                Role = teacher.Role,
                Group = null,
                TeacherProfile = t
            });
        }
        public async Task RegisterStaff(RegistrationDTO staff)
        {
            await Register(new User
            {
                Login = staff.Login,
                Password = EncodePassword(staff.Password),
                Role = staff.Role,
                Group = null,
                TeacherProfile = null
            });
        }

        public async Task<JsonResult> MobileLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                user.Role != Role.STUDENT && user.Role != Role.TEACHER)
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return CreateToken(user);
        }
        public async Task<JsonResult> WebLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null ||
                user.Role == Role.STUDENT ||
                user.Role == Role.TEACHER)
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

        private async Task Register(User user)
        {
            if (await _context.Users.AnyAsync(u => u.Login == user.Login))
            {
                throw new BadHttpRequestException(ErrorStrings.LOGIN_TAKEN_ERROR);
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        private async Task<User?> GetUserByCredentials(LoginCredentials credentials)
        {
            var hashedPassword = EncodePassword(credentials.Password);
            return await _context.Users
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
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            return new ClaimsIdentity(claims, "Token");
        }
        private string EncodePassword(string password) =>
            Convert.ToHexString(
                SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(password))
                );

    }
}
