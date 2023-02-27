using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class LessonCreateDTO
    {
        [Required]
        public Guid TeacherId { get; set; }
        [Required]
        public Guid SubjectId { get; set; }
        [Required]
        public List<int> GroupsNum { get; set; }
        [Required]
        public int CabinetNum { get; set; }
        [Required]
        public Guid TimeslotId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
