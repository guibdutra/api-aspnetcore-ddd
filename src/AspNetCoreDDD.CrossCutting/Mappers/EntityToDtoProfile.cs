using AspNetCoreDDD.Domain.Dto.User;
using AspNetCoreDDD.Domain.Entities;
using AutoMapper;

namespace AspNetCoreDDD.CrossCutting.Mappers
{
    public class EntityToDtoProfile: Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity> ()
                .ReverseMap();

            CreateMap<UserDtoCreateResult, UserEntity>()           
                .ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();   
        }
    }
}