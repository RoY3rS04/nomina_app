using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTOs;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;
using AutoMapper;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Repository<User> _userRepository;
        private readonly AuthService _authService;

        public AuthController(Repository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _authService = new AuthService(_userRepository, mapper);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto loginDto)
        {
           
            var response = await _authService.Login(loginDto);

            return response.SendResponse(this);

        }
    }
}
