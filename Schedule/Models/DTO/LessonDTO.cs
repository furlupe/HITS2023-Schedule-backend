namespace Schedule.Models.DTO
{
    public class LessonDTO
    {
        public string Subject { get; set; }
        public CabinetDTO Cabinet { get; set; }
        public List<int> GroupsNum { get; set; }
        public string Teacher { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }

    }
}
