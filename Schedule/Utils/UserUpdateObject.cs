using Schedule.Enums;
using Schedule.Models;

namespace Schedule.Utils
{
    public class UserUpdateObject
    {
        public Role Role { get; set; }
        public Teacher? Teacher { get; set; }
        public Group? Group { get; set; }
    }
}
