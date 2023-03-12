using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Schedule.Utils
{
    public class JwtConfigurations
    {
        public const string Issuer = "Furlupe";
        public const string Audience = "JwtClient";
        private const string Key = "FortniteHambugerSussyBalls445";
        public const int Lifetime = 5;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new(Encoding.ASCII.GetBytes(Key));
    }
}