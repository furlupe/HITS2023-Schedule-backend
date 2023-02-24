using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class LoginCredentials
    {
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
