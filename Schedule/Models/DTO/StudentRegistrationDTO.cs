using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class StudentRegistrationDTO
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public Guid GroupID { get; set; }
    }
}
