using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedModels.DTOs;
using NominaAPI.Repository;
using NominaAPI.Services;
using SharedModels;

namespace NominaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Repository<User> _userRepository;
        private readonly AuthService _authService;

        public AuthController(Repository<User> userRepository)
        {
            _userRepository = userRepository;
            _authService = new AuthService(_userRepository);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto loginDto)
        {

            var result = await _authService.Login(loginDto);

            return SendStatus(result.response);

        }

        private ObjectResult? SendStatus((int status, string msg) response)
        {
            switch (response.status)
            {
                case StatusCodes.Status200OK:
                    return Ok(response.msg);
                case StatusCodes.Status400BadRequest:
                    return BadRequest(response.msg);
                case StatusCodes.Status404NotFound:
                    return NotFound(response.msg);
                case StatusCodes.Status401Unauthorized:
                    return Unauthorized(response.msg);
                case StatusCodes.Status500InternalServerError:
                    return StatusCode(response.status, response.msg);
                default: return null;
            }
        }
    }
}
