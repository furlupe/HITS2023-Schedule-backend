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
        public Guid Role { get; set; }
        
        public Guid? TeacherID { get; set; }
        public Guid? GroupID { get; set; }
    }
}
