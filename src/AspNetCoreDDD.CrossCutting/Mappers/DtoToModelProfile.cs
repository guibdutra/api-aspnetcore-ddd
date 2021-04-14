using AspNetCoreDDD.Domain.Dto.User;
using AspNetCoreDDD.Domain.Models.User;
using AutoMapper;

namespace AspNetCoreDDD.CrossCutting.Mappers
{
    public class DtoToModelProfile: Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDto>()
                .ReverseMap();

            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();
                
            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();  
        }
    }
}