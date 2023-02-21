namespace Schedule.Models
{
    public class UserTeacher : User
    {
        public Teacher Profile { get; set; } // rename, "profile" doesn't quite tell wtf that actually is
    }
}
