using Schedule.Enums;

namespace Schedule.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
        public Teacher? TeacherProfile { get; set; }
        public Group? Group { get; set; }
    }
}
