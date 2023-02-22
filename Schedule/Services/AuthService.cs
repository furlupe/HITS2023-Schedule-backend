using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Models;
using MoviesCatalog.Utils;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
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
        public async Task Register(RegistrationDTO user)
        {
            Teacher? teacher = null;
            Group? group = null;
            switch (user.Role)
            {
                case Role.STUDENT:
                    {
                        if (user.GroupNumber is null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.STUDENT_NO_GROUP_ERROR);
                        }

                        if (user.TeacherID is not null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.STUDENT_TEACHER_GIVEN_ERROR);
                        }

                        group = await _context.Groups.SingleOrDefaultAsync(g => g.Number == user.GroupNumber);
                        if (group is null) 
                        {
                            throw new BadHttpRequestException(ErrorStrings.GROUP_WRONG_ID_ERROR);
                        }

                        break;
                    }
                case Role.TEACHER:
                    {
                        if (user.TeacherID is null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.TEACHER_NO_ID_ERROR);
                        }

                        if (user.GroupNumber is not null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.TEACHER_GROUP_GIVEN_ERROR);
                        }

                        teacher = await _context.Teachers.SingleOrDefaultAsync(t => t.Id == user.TeacherID);
                        if (teacher is null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.TEACHER_WRONG_ID_ERROR);
                        }

                        if (await _context.Users.AnyAsync(u => u.TeacherProfile == teacher))
                        {
                            throw new BadHttpRequestException(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR);
                        }

                        break;
                    }
                case Role.EDITOR:
                case Role.ADMIN: 
                    {
                        if (user.GroupNumber is not null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.EDITOR_ADMIN_GROUP_GIVEN_ERROR);
                        }

                        if (user.TeacherID is not null)
                        {
                            throw new BadHttpRequestException(ErrorStrings.EDITOR_ADMIN_TEACHER_GIVEN_ERROR);
                        }
                    }
                    break;
                case Role.ROOT: 
                    throw new BadHttpRequestException(ErrorStrings.ROOT_GIVEN_ERROR);
                default: break;
            }

            if (await _context.Users.AnyAsync(u => u.Login == user.Login))
            {
                throw new BadHttpRequestException(ErrorStrings.LOGIN_TAKEN_ERROR);
            }

            await _context.Users.AddAsync(new User
            {
                Login = user.Login,
                Password = EncodePassword(user.Password),
                Role = user.Role,
                TeacherProfile = teacher,
                Group = group
            });
            await _context.SaveChangesAsync();
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
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim("id", user.Id.ToString()),
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
