namespace Schedule.Models
{
    public class Timeslot
    {
        public Guid Id { get; set; }
        public TimeOnly StartsAt { get; set; }
        public TimeOnly EndsAt { get; set; }
    }
}
