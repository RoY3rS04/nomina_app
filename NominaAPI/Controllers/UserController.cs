using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.Data;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> CreateUser(UserCreateDto createDto)
        {
            var response = await _userService.CreateUser(createDto, this);

            return response.SendResponse(this);
        }
    }
}
