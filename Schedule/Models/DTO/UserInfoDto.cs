using Schedule.Enums;

namespace Schedule.Models.DTO
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public ICollection<RoleEnum> Roles { get; set; }
        public Guid? TeacherId { get; set; }
        public int? Group { get; set; }
    }
}
