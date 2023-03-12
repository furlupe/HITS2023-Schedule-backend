using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class RegistrationDto
    {
        [Required]
        [StringLength(30, MinimumLength = 6, ErrorMessage = "Login too short, minimum 6 characters are required")]
        [RegularExpression(@"^\w*[a-zA-Z]\w*$", ErrorMessage = "Login must contain letters, digits or underscores")]
        public string Login { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Password too short, minimum 6 characters are required")]
        [RegularExpression(@"^[\w\d-]*$", ErrorMessage = "Password must contain english letters, digits and underscores")]
        public string Password { get; set; }
        [Required, MinLength(1)]
        public ICollection<RoleEnum> Roles { get; set; }
        public Uri? AvatarLink { get; set; }
        public Guid? TeacherID { get; set; }
        public int? GroupNumber { get; set; }
    }
}
