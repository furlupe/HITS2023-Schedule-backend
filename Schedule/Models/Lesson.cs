namespace Schedule.Models
{
    public class Lesson
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Timeslot Timeslot { get; set; }
        public Cabinet Cabinet { get; set; }
        public Group Group { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
    }
}
