namespace Schedule.Models.DTO
{
    public class TimeslotDTO
    {
        public Guid Id { get; set; }
        public DateTime startAt { get; set; }
        public DateTime endsAt { get; set; }
    }
}
