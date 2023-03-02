using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class RefreshToken
    {
        [Key]
        public string Value { get; set; }
        public User User { get; set; }
        public DateTime Expiry { get; set; }
    }
}
