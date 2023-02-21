using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class TeacherRegistrationDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid TeacherID { get; set; }
    }
}
