using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class RegistrationDto
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Role Role { get; set; }

        public Guid? TeacherID { get; set; }
        public int? GroupNumber { get; set; }
    }
}
