using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class SubjectShortDto
    {
        [Required]
        public string Name { get; set; }
    }
}
