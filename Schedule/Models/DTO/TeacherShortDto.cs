using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class TeacherShortDto
    {
        [Required]
        public string Name { get; set; }
    }
}
