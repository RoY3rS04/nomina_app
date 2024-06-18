using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Data;
using NominaAPI.Http.Responses;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using SharedModels.DTOs.User;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        
        public UserController(Repository<User> userRepository, IMapper mapper)
        {
            _userService = new UserService(userRepository, mapper);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<List<UserDto>>>> GetAllUsers()
        {
            var response = await _userService.GetAll();

            return response.SendResponse(this);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UserDto>>> GetUserById(int id)
        {

            var response = await _userService.GetById(id);

            return response.SendResponse(this);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UserDto>>> CreateUser(UserCreateDto createDto)
        {
            var response = await _userService.CreateUser(createDto, this);

            return response.SendResponse(this);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UserDto>>> UpdateUser(int id, UserUpdateDto updateDto)
        {
            var response = await _userService.Update(id, updateDto, this);

            return response.SendResponse(this);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Response<UserDto>>> DeleteUser(int id)
        {
            var response = await _userService.Delete(id);

            return response.SendResponse(this);
        }
    }
}
