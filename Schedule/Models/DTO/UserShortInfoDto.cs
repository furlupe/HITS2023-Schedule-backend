using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class UserShortInfoDto
    {
        [Required, MinLength(1)]
        public ICollection<RoleEnum> Roles { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Group { get; set; }
        public Uri? Avatar { get; set; }
    }
}
