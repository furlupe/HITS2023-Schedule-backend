using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class UserShortInfoDto
    {
        [Required]
        public ICollection<RoleEnum> Roles { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Group { get; set; }
    }
}
