using AutoMapper;
using EfCore.Interceptors.Api.Models.Dtos;
using EfCore.Interceptors.Domain.Entities;

namespace EfCore.Interceptors.Api.Mappers;

public class ItemMapper : Profile
{
    public ItemMapper()
    {
        CreateMap<Item, ItemDto>().ReverseMap();   
    }
}