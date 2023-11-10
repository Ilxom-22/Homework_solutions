using AutoMapper;
using IdentityDb.Application.Common.Identity.Models;
using IdentityDb.Domain.Entities;

namespace IdentityDb.Infrastructure.Common.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<SignUpDetails, User>();
    }
}