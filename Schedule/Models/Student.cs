namespace Schedule.Models
{
    public class Student : User
    {
        public string Name { get; set; }
        public Group Group { get; set; }
    }
}
