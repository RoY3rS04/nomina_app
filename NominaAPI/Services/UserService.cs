using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using SharedModels;
using SharedModels.DTOs.User;

namespace NominaAPI.Services
{
    using BCrypt.Net;
    using Microsoft.AspNetCore.JsonPatch;
    using Microsoft.EntityFrameworkCore;

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

        public async Task<UserResponse> GetById(int id)
        {
            if(id <= 0)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The id must be a positive number"
                };
            }

            try
            {

                var user = await _userRepository.GetById(id);

                if(user == null)
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "There's no user with that id"
                    };
                }

                return new UserResponse
                {
                    User = _mapper.Map<UserDto>(user),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "User found successfully!"
                };
            } catch(Exception e)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong"
                };
            }
        }

        public async Task<UsersResponse> GetAll()
        {
            try
            {

                var users = await _userRepository.GetAllAsync();

                return new UsersResponse
                {
                    Users = _mapper.Map<List<UserDto>>(users),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Users retrieved successfully!"
                };
            } catch(Exception e)
            {
                return new UsersResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong when getting users"
                };
            }
        }

        public async Task<UserResponse> Update(
            int id,
            UserUpdateDto updateDto,
            ControllerBase controller
        ) {
            if (id <= 0)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The id must be a positive number"
                };
            }

            try
            {
                var user = await _userRepository.GetById(id);

                if (user == null)
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "There's no user with that id"
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

                //TODO
                // - ADD AUTHENTICATION REQUIREMENTS

                /*if(!BCrypt.Verify(updateDto.ActualPassword, user.Password))
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = "Invalid password"
                    };
                }*/

                updateDto = new UserUpdateDto
                {
                    Name = updateDto.Name ?? user.Name,
                    Email = updateDto.Email ?? user.Email,
                    IsAdmin = updateDto.IsAdmin ?? user.IsAdmin
                };
                
                _mapper.Map(updateDto,user);

                using(var transaction = await _userRepository.BeginTransactionAsync())
                {
                    try
                    {
                        await _userRepository.SaveChangesAsync();
                        transaction.Commit();

                        return new UserResponse
                        {
                            User = _mapper.Map<UserDto>(user),
                            StatusCode = StatusCodes.Status200OK,
                            Message = "User updated successfully!"
                        };
                    } catch(DbUpdateConcurrencyException)
                    {
                        if(!await _userRepository.ExistsAsync(u => u.Id == id))
                        {
                            return new UserResponse
                            {
                                StatusCode = StatusCodes.Status404NotFound,
                                Message = "There's no user with that id"
                            };
                        }

                        return new UserResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Something went wrong when updating the user"
                        };
                    }
                    catch(Exception e)
                    {
                        transaction.Rollback();

                        return new UserResponse
                        {
                            StatusCode = StatusCodes.Status500InternalServerError,
                            Message = "Something went wrong when updating the user"
                        };
                    }
                }
            } catch(Exception e)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong when updating the user"
                };
            }
        }

        public async Task<UserResponse> Delete(int id)
        {
            if (id <= 0)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = "The id must be a positive number"
                };
            }

            try
            {
                var user = await _userRepository.GetById(id);

                if(user == null)
                {
                    return new UserResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "There's no user with that id"
                    };
                }

                await _userRepository.DeleteAsync(user);

                return new UserResponse
                {
                    StatusCode = StatusCodes.Status200OK,
                    Message = "User deleted successfully!"
                };
            } catch(Exception e)
            {
                return new UserResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong when deleting user"
                };
            }
        }
    }
}
