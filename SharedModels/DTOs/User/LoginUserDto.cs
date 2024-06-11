using System.ComponentModel.DataAnnotations;

namespace SharedModels.DTOs
{
    public class LoginUserDto
    {
        [Required, StringLength(50)]
        public string Email { get; set; }

        [Required, StringLength(50)]
        public string Password { get; set; }
    }
}
