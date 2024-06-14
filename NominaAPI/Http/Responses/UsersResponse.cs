using SharedModels.DTOs.User;

namespace NominaAPI.Http.Responses
{
    public class UsersResponse: ApiResponse
    {
        public List<UserDto>? Users { get; set; }
    }
}
