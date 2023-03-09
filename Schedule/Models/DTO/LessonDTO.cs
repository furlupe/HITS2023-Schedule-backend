using Schedule.Enums;

namespace Schedule.Models.DTO
{
    public class LessonDTO
    {
        public Guid Id { get; set; }
        public LessonShortDto Lesson { get; set; }
        public TimeslotDTO Timeslot { get; set; }
        public DateTime Date { get; set; }
    }
}
