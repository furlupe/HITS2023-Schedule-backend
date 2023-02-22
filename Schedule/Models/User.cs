namespace Schedule.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Teacher? TeacherProfile { get; set; }
        public Group? Group { get; set; }
    }
}
