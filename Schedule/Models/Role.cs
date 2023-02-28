using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class Role
    {
        [Key]
        public Guid Id { get; set; }
        public RoleEnum Value { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
