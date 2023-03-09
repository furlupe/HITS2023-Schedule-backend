namespace Schedule.Models
{
    public class LessonScheduled
    {
        public Guid Id { get; set; }
        public Lesson BaseLesson { get; set; }
        public Timeslot Timeslot { get; set; }
        public DateOnly Date { get; set; }
    }
}
