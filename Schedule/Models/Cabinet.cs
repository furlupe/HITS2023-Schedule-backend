using System.ComponentModel.DataAnnotations;

namespace Schedule.Models
{
    public class Cabinet
    {
        [Key]
        public int Number { get; set; }
        public string Name { get; set; }
    }
}
