using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class RegistrationDto
    {
        [Required]
        [StringLength(6, ErrorMessage = "Login too short, minimum 6 characters are required")]
        [RegularExpression(@"^[\w\d-]{6,}$", ErrorMessage = "Login must contain only letters, digits and underscores")]
        public string Login { get; set; }
        [Required]
        [StringLength(6, ErrorMessage = "Password too short, minimum 6 characters are required")]
        [RegularExpression(@"^[\w\d-]{6,}$", ErrorMessage = "Password must contain only letters, digits and underscores")]
        public string Password { get; set; }
        [Required]
        public ICollection<RoleEnum> Roles { get; set; }

        public Guid? TeacherID { get; set; }
        public int? GroupNumber { get; set; }
    }
}
