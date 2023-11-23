using AutoMapper;
using EfCore.Interceptors.Api.Models.Dtos;
using EfCore.Interceptors.Domain.Entities;

namespace EfCore.Interceptors.Api.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}