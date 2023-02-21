using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesCatalog.Models;
using MoviesCatalog.Utils;
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
        public Task Register(RegistrationDTO user)
        {
            throw new NotImplementedException();
        }
        public Task RegisterStudent(StudentRegistrationDTO student)
        {
            throw new NotImplementedException();
        }
        public Task RegisterTeacher(TeacherRegistrationDTO teacher)
        {
            throw new NotImplementedException();
        }
        public async Task<JsonResult> MobileLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null || user.Role.Name != "COMMON")
            {
                throw new BadHttpRequestException("Invalid credentials");
            }

            return CreateToken(user);
        }
        public async Task<JsonResult> WebLogin(LoginCredentials credentials)
        {
            var user = await GetUserByCredentials(credentials);
            if (user is null || user.Role.Name == "COMMON")
            {
                throw new BadHttpRequestException("Invalid credentials");
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
                .Include(u => u.Role)
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
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            return new ClaimsIdentity(claims, "Token");
        }
        private string EncodePassword(string password) =>
            Convert.ToHexString(
                SHA256.Create().ComputeHash(new UTF8Encoding().GetBytes(password))
                );
    }
}
