using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModels.DTOs.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Email { get; set; }

        public bool IsAdmin { get; set; }
    }
}
