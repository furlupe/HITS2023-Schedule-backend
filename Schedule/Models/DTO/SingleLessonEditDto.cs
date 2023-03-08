using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class SingleLessonEditDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Guid TimeslotId { get; set; }
    }
}
