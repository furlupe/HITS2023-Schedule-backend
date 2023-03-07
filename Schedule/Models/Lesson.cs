using Schedule.Enums;

namespace Schedule.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public Timeslot Timeslot { get; set; }
        public Cabinet Cabinet { get; set; }
        public ICollection<Group> Groups { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public DayOfWeek Day { get; set; }
        public LessonType Type { get; set; }
        public DateOnly DateFrom { get; set; }
        public DateOnly DateUntil { get; set; }
    }
}
