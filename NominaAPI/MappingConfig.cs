using AutoMapper;
using SharedModels.DTOs;
using SharedModels;
using SharedModels.DTOs.User;
using SharedModels.DTOs.Ingresos;
using SharedModels.DTOs.Deducciones;

namespace NominaAPI
{
    public class MappingConfig: Profile
    {
        public MappingConfig() {
        
            //User DTOs
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();

            //Ingresos DTOs
            CreateMap<Ingresos, IngresosDto>().ReverseMap();
            CreateMap<Ingresos, IngresosCreateDto>().ReverseMap();
            CreateMap<Ingresos, IngresosUpdateDto>().ReverseMap();

            CreateMap<Deducciones, DeduccionesDto>().ReverseMap();
            CreateMap<Deducciones, DeduccionesCreateDto>().ReverseMap();    
            CreateMap<Deducciones, DeduccionesUpdateDto>().ReverseMap();
        }
    }
}
