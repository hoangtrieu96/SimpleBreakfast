using AutoMapper;
using SimpleBreakfast.DTO;
using SimpleBreakfast.Models.Entities;

namespace SimpleBreakfast.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Breakfast, BreakfastDTO>().ReverseMap();
    }
}