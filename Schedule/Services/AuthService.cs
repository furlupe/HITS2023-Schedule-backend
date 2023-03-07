using Microsoft.EntityFrameworkCore;
using Schedule.Enums;
using Schedule.Models;
using Schedule.Models.DTO;
using Schedule.Resources;
using Schedule.Utils;
using System.Data;

namespace Schedule.Services
{
    public class AuthService : IAuthService
    {
        private readonly IResource _resource;
        private readonly ITokenService _tokenService;
        public AuthService(ITokenService tokenService, IResource resource)
        {
            _tokenService = tokenService;
            _resource = resource;
        }

        public async Task<TokensDto> MobileLogin(LoginCredentials credentials)
        {
            var user = await _resource.GetUserByCredentials(
                credentials.Login, 
                Credentials.EncodePassword(credentials.Password)
                );

            if (!user.Roles.Any(r => r.Value == RoleEnum.STUDENT || r.Value == RoleEnum.TEACHER))
            {
                throw new BadHttpRequestException(ErrorStrings.INVALID_CREDENTIALS_ERROR);
            }

            return await Login(user);
        }
        public async Task<TokensDto> WebLogin(LoginCredentials credentials)
        {
            var user = await _resource.GetUserByCredentials(
                credentials.Login,
                Credentials.EncodePassword(credentials.Password)
                );

            if (!user.Roles.Any(r => 
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
            await _resource.AddBlacklistedToken(new BlacklistedToken { Value = token });
        }

        public async Task Register(RegistrationDTO user)
        {
            var group = await _resource.GetGroup(user.GroupNumber);
            if (user.Roles.Any(r => r == RoleEnum.STUDENT) && group is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.GROUP_WRONG_ID_ERROR, user.GroupNumber)
                    );
            }

            var teacher = await _resource.GetTeacher(user.TeacherID);
            if (user.Roles.Any(r => r == RoleEnum.TEACHER) && teacher is null)
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_NO_ID_ERROR, user.TeacherID)
                    );
            }

            if (user.Roles.Any(r => r == RoleEnum.TEACHER) &&
                await _resource.DoesTeacherAccountExist(teacher))
            {
                throw new BadHttpRequestException(
                    string.Format(ErrorStrings.TEACHER_ACCOUNT_EXISTS_ERROR, user.TeacherID)
                    );
            }

            if (await _resource.IsLoginTaken(user.Login))
            {
                throw new BadHttpRequestException(ErrorStrings.LOGIN_TAKEN_ERROR, StatusCodes.Status409Conflict);
            }

            var roles = await _resource.GetRoles(user.Roles);

            await _resource.AddUser(new User
            {
                Login = user.Login,
                Password = Credentials.EncodePassword(user.Password),
                Roles = roles,
                TeacherProfile = teacher,
                Group = group
            });

        }

        public async Task<TokensDto> Refresh(string token)
        {
            var rt = await _resource.GetRefreshToken(token);

            if (rt.Expiry < DateTime.UtcNow)
            {
                throw new BadHttpRequestException(string.Empty, StatusCodes.Status401Unauthorized);
            }

            return await Login(rt.User);
        }

        private async Task<TokensDto> Login(User user)
        {
            var refreshToken = _tokenService.CreateRefreshToken();
            var rtUser = await _resource.GetRefreshTokenByUser(user);

            var response = new TokensDto
            {
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = refreshToken
            };

            if (rtUser is not null)
            {
                await _resource.RemoveRefreshToken(rtUser);
            }

            await _resource.AddRefreshToken(new RefreshToken
            {
                Value = refreshToken,
                User = user,
                Expiry = DateTime.UtcNow.AddDays(60)
            });

            return response;
        }

    }
}
