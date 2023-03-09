using Schedule.Enums;

namespace Schedule.Models.DTO
{
    public class LessonShortDto
    {
        public Guid Id { get; set; }
        public string Teacher { get; set; }
        public ICollection<int> Groups { get; set; }
        public LessonType Type { get; set; }
        public string Subject { get; set; }
        public CabinetDTO Cabinet { get; set; }
    }
}
