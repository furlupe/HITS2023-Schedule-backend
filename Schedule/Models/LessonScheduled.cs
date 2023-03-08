namespace Schedule.Models
{
    public class LessonScheduled
    {
        public Guid Id { get; set; }
        public Lesson Lesson { get; set; }
        public Timeslot Timeslot { get; set; }
        public DateOnly Date { get; set; }
    }
}
