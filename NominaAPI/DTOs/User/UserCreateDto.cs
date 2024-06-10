using System.ComponentModel.DataAnnotations;

namespace NominaAPI.DTOs.User
{
    public class UserCreateDto
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }

        [Required]
        public bool IsAdmin { get; set; }
    }
}
