using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.User;

namespace NominaAPI.Services
{
    using BCrypt.Net;
    public class UserService
    {
        private readonly Repository<User> _userRepository;
        private readonly IMapper _mapper;

        public UserService(Repository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserResponse> CreateUser(UserCreateDto userCreate, ControllerBase controller)
        {

            if(userCreate == null)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "You must provide all the needed data"
                };
            }

            try
            {

                if(await _userRepository.ExistsAsync(u => u.Email ==  userCreate.Email))
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "There's already a user with that email"
                    };
                }

                if(!controller.ModelState.IsValid)
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status400BadRequest,
                        Message = "Invalid user model"
                    };
                }

                var newStudent = _mapper.Map<User>(userCreate);

                newStudent.Password = BCrypt.HashPassword(newStudent.Password);

                await _userRepository.CreateAsync(newStudent);

                return new UserResponse
                {
                    User = _mapper.Map<UserDto>(newStudent),
                    StatusCode = StatusCodes.Status201Created,
                    Message = "User created successfully!"
                };
            } catch(Exception ex)
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
