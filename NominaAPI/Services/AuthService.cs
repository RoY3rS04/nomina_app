using Microsoft.AspNetCore.Identity.Data;
using SharedModels.DTOs;
using NominaAPI.Repository;
using SharedModels;

namespace NominaAPI.Services
{
    using BCrypt.Net;
    using Microsoft.AspNetCore.Mvc;

    public class AuthService
    {

        private readonly Repository<User> _userRepository;

        public AuthService(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        //TODO: CHANGE FROM TUPLES TO CLASS
        public async Task<(User? user, (int status, string msg) response)> Login(LoginUserDto loginDto)
        {

            if(loginDto == null)
            {
                return (
                    null,
                    (StatusCodes.Status400BadRequest, "Invalid or insuficient data")
                );
            }

            try
            {
                var user = await _userRepository.GetAsync(u => u.Email == loginDto.Email);

                if (user == null)
                {
                    return (
                        null,
                        (StatusCodes.Status404NotFound, "User with those credentials does'nt exists")
                    );
                }

                if (!BCrypt.Verify(loginDto.Password, user.Password))
                {
                    return (
                        null,
                        (StatusCodes.Status401Unauthorized, "Invalid credentials")
                    );
                }

                return (
                    user,
                    (StatusCodes.Status200OK, "Authenticated Successfully")
                );
            }
            catch (Exception ex)
            {
                return (
                    null,
                    (StatusCodes.Status500InternalServerError, "Something went wrong")
                );
            }
        }
    }
}
