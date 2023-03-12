﻿using System.ComponentModel.DataAnnotations;

namespace Schedule.Models.DTO
{
    public class CabinetDTO
    {
        [Required]
        public int Number { get; set; }
        public string? Name { get; set; }
    }
}
