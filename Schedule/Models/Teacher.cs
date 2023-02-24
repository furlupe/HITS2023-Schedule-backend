namespace Schedule.Models
{
    public class Teacher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
