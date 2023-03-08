namespace Schedule.Models.DTO
{
    public class LessonDTO
    {
        public int Type { get; set; }
        public string Subject { get; set; }
        public CabinetDTO Cabinet { get; set; }
        public string Teacher { get; set; }
        public TimeslotDTO Timeslot { get; set; }
        public List<int> GroupsNum { get; set; }
        public DateTime Date { get; set; }
    }
}
