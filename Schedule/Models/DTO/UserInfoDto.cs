using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class UserInfoDto
    {
        [Required]
        public Role Role { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Group { get; set; }
    }
}
