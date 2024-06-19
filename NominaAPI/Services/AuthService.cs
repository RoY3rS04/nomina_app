using Microsoft.AspNetCore.Identity.Data;
using SharedModels.DTOs;
using NominaAPI.Repository;
using SharedModels;

namespace NominaAPI.Services
{
    using AutoMapper;
    using BCrypt.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using NominaAPI.Http.Responses;
    using SharedModels.DTOs.User;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class AuthService
    {

        private readonly Repository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthService(Repository<User> userRepository, IMapper mapper, IConfiguration config)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _config = config;
        }

        public async Task<TokenResponse> Login(LoginUserDto loginDto)
        {

            if(loginDto == null)
            {
                return new TokenResponse
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
                    return new TokenResponse
                    {
                        StatusCode = StatusCodes.Status404NotFound,
                        Message = "User with those credentials does'nt exists"
                    };
                }

                if (!BCrypt.Verify(loginDto.Password, user.Password))
                {
                    return new TokenResponse
                    {
                        StatusCode = StatusCodes.Status401Unauthorized,
                        Message = "Invalid Credentials"
                    };
                }

                return new TokenResponse
                {
                    Token = GenerateJwtToken(user),
                    StatusCode = StatusCodes.Status200OK,
                    Message = "Authenticated successfully!"
                };
            }
            catch (Exception ex)
            {
                return new TokenResponse
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = "Something went wrong"
                };
            }
        }

        private string GenerateJwtToken(User user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("Key"));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Name),
                    // Agregar cualquier otro claim necesario
                }),
                Issuer = jwtSettings.GetValue<string>("Issuer"),
                Audience = jwtSettings.GetValue<string>("Audience"),
                Expires = DateTime.UtcNow.AddHours(1), // Tiempo de expiración del token
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
