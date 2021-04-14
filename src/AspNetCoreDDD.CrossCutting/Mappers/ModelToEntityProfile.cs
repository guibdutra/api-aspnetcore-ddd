using System.Security.Cryptography;
using AspNetCoreDDD.Domain.Entities;
using AspNetCoreDDD.Domain.Models.User;
using AspNetCoreDDD.Infrastructure.Security;
using AutoMapper;

namespace AspNetCoreDDD.CrossCutting.Mappers
{
    public class ModelToEntityProfile: Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>()            
             .ReverseMap()
             .ForMember(dst => dst.Password, map => map.MapFrom(src => new DealingHash(new SHA512Managed()).GenerateHash(src.Password)));
        }
    }
}