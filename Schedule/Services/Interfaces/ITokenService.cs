using Schedule.Models;

namespace Schedule.Services.Interfaces
{
    public interface ITokenService
    {
        public string CreateAccessToken(User user);
        public string CreateRefreshToken();
    }
}
