using Microsoft.AspNetCore.Authorization;
using Schedule.Enums;

namespace Schedule.Utils
{
    public class RoleAuthorizationAttribute : AuthorizeAttribute
    {
        public RoleAuthorizationAttribute(RoleEnum role)
        {
            Roles = role.ToString().Replace(" ", string.Empty);
        }
    }
}
