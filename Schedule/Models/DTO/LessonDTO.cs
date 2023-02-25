namespace Schedule.Models.DTO
{
    public class LessonDTO
    {
        public string Name { get; set; }
        public string Cabinet { get; set; }
        public List<int> Group { get; set; }
        public string Teacher { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
