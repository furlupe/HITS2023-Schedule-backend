using Microsoft.AspNetCore.Authorization;
using Schedule.Enums;
using System.Reflection.Metadata;

namespace Schedule.Utils
{
    public class RoleAuthorizationAttribute : AuthorizeAttribute
    {
        public RoleAuthorizationAttribute(Role role) 
        {
            Roles = role.ToString().Replace(" ", string.Empty);
        }
    }
}
