using AutoMapper;
using SharedModels.DTOs;
using SharedModels;
using SharedModels.DTOs.User;

namespace NominaAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig() {
        
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}
