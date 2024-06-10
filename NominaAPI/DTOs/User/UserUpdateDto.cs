﻿using System.ComponentModel.DataAnnotations;
namespace NominaAPI.DTOs.User
{
    public class UserUpdateDto
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [StringLength(50)]
        public string? ActualPassword { get; set; }

        [StringLength(50)]
        public string? NewPassword { get; set; }

        public bool? IsAdmin { get; set; }
    }
}
