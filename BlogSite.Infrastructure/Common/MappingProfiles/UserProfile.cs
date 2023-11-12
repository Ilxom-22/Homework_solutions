using AutoMapper;
using BlogSite.Application.Common.Dtos;
using BlogSite.Application.Common.Identity.Models;
using BlogSite.Domain.Entities;

namespace BlogSite.Infrastructure.Common.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpDetails, User>();
        CreateMap<User, UserDto>();
    }
}