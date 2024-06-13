using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedModels;
using SharedModels.DTOs.User;

namespace NominaAPI.Http.Responses
{
    public class UserResponse: ApiResponse
    {

        public UserDto? User { get; set; }

    }
}
