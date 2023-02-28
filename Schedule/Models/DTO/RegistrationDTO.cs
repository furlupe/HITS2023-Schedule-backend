using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class RegistrationDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public ICollection<RoleEnum> Roles { get; set; }

        public Guid? TeacherID { get; set; }
        public int? GroupNumber { get; set; }
    }
}
