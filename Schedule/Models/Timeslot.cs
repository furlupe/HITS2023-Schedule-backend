namespace Schedule.Models
{
    public class Timeslot
    {
        public Guid Id { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set;}
    }
}
