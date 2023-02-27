namespace Schedule.Models.DTO
{
    public class LessonDTO
    {
        public string Subject { get; set; }
        public CabinetDTO Cabinet { get; set; }
        public List<int> GroupsNum { get; set; }
        public string Teacher { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
