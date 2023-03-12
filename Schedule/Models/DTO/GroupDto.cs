using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class GroupDto
    {
        [Required]
        public int Number { get; set; }
    }
}
