using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NominaAPI.DTOs;
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
        private readonly AuthService _authService = new AuthService();

        public AuthController(Repository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<User>> LoginUser(LoginUserDto loginDto)
        {

            if(loginDto == null)
            {
                return BadRequest("Invalid or insuficient data");
            }

            try
            {
                var user = await _userRepository.GetAsync(u => u.Email == loginDto.Email);

                if (user == null)
                {
                    return NotFound("User not found or (invalid credentials)");
                }

                if (!await _authService.Login(loginDto, user.Password))
                {
                    return Unauthorized("Invalid Credentials");
                }

                return Ok("Authenticated sucessfully!");
            } catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something went wrong");
            }
        }
    }
}
