using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SharedModels;

namespace NominaAPI.Http.Responses
{
    public class UserResponse: ApiResponse
    {

        public User? User { get; set; }

    }
}
