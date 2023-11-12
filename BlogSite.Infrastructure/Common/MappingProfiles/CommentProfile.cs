using AutoMapper;
using BlogSite.Application.Common.Dtos;
using BlogSite.Domain.Entities;

namespace BlogSite.Infrastructure.Common.MappingProfiles;

public class CommentProfile : Profile
{
    public CommentProfile()
    {
        CreateMap<Comment, CommentDto>()
            .ForMember(dest => dest.Date, options => options
                .MapFrom(src => src.ModifiedDate != null ? src.ModifiedDate : src.CreatedDate))
            .ReverseMap();
    }
}
