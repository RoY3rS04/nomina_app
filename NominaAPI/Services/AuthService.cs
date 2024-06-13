using Microsoft.AspNetCore.Identity.Data;
using SharedModels.DTOs;
using NominaAPI.Repository;
using SharedModels;

namespace NominaAPI.Services
{
    using AutoMapper;
    using BCrypt.Net;
    using Microsoft.AspNetCore.Mvc;
    using NominaAPI.Http.Responses;
    using SharedModels.DTOs.User;

    public class AuthService
    {

        private readonly Repository<User> _userRepository;
        private readonly IMapper _mapper;

        public AuthService(Repository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> Login(LoginUserDto loginDto)
        {

            if(loginDto == null)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "Invalid or insuficient data"
                };
            }

            try
            {
                var user = await _userRepository.GetAsync(u => u.Email == loginDto.Email);

                if (user == null)
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "User with those credentials does'nt exists"
                    };
                }

                if (!BCrypt.Verify(loginDto.Password, user.Password))
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = "Invalid Credentials"
                    };
                }



                return new UserResponse
                {
                    User = _mapper.Map<UserDto>(user),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Authenticated successfully!"
                };
            }
            catch (Exception ex)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong"
                };
            }
        }
    }
}
