using Schedule.Enums;
using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        [EnumDataType(typeof(RoleEnum))]
        public ICollection<RoleEnum> Roles { get; set; }
        public TeacherDTO? TeacherId { get; set; }
        public int? Group { get; set; }
    }
}
