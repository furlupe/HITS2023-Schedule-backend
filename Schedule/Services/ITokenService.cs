using Schedule.Models;

namespace Schedule.Services
{
    public interface ITokenService
    {
        public string CreateAccessToken(User user);
        public string CreateRefreshToken();
    }
}
