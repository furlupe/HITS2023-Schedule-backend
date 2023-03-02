using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Schedule.Models;
using Schedule.Utils;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Schedule.Services
{
    public class TokenService : ITokenService
    {
        private readonly IRandomStringGenerator _randomStringGenerator;
        public TokenService(IRandomStringGenerator randomStringGenerator)
            => _randomStringGenerator = randomStringGenerator;
        public string CreateAccessToken(User user)
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

            return enctoken;
        }

        public string CreateRefreshToken()
        {
            return _randomStringGenerator.GetRandomString(26);
        }

        private ClaimsIdentity GetIdentity(User user)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            foreach (var role in user.Roles.Select(r => r.Value))
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            return new ClaimsIdentity(claims, "Token");
        }
    }
}
