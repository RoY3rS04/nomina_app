using AutoMapper;
using SharedModels.DTOs;
using SharedModels;

namespace NominaAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig() {
        
            CreateMap<User, LoginUserDto>().ReverseMap();

        }
    }
}
