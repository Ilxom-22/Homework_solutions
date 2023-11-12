using AutoMapper;
using BlogSite.Application.Common.Dtos;
using BlogSite.Domain.Entities;

namespace BlogSite.Infrastructure.Common.MappingProfiles;

public class BlogProfile : Profile
{
    public BlogProfile()
    {
        CreateMap<BlogDto, Blog>().ReverseMap();
    }
}