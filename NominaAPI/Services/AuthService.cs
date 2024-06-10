using Microsoft.AspNetCore.Identity.Data;
using NominaAPI.DTOs;
using NominaAPI.Repository;
using SharedModels;

namespace NominaAPI.Services
{
    using BCrypt.Net;
    public class AuthService
    {

        public async Task<bool> Login(LoginUserDto loginDto, string userPassword)
        {

            return BCrypt.Verify(loginDto.Password, userPassword);

        }
    }
}
