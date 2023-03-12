using Microsoft.AspNetCore.Authorization;
using Schedule.Enums;

namespace Schedule.Utils
{
    public class RoleAuthorizationAttribute : AuthorizeAttribute
    {
        public RoleAuthorizationAttribute(params RoleEnum[] roles)
        {
            var stringRoles = roles.Select(role => role.ToString()).ToArray();
            Roles = string.Join(",", stringRoles);
        }
    }
}