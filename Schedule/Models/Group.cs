using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class Group
    {
        [Key]
        public int Number { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
