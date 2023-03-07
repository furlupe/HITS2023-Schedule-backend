using Schedule.Enums;
using Schedule.Utils;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class LessonCreateDTO
    {
        [Required]
        public Guid Teacher { get; set; }
        [Required]
        public Guid Subject { get; set; }
        [Required]
        public List<int> Groups { get; set; }
        [Required]
        public int Cabinet { get; set; }
        [Required]
        public Guid Timeslot { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }
        [Required]
        public LessonType Type { get; set; }
        [Required]
        public DateTime StartsAt { get; set; }
        [Required]
        public DateTime EndsAt { get; set; }
    }
}
