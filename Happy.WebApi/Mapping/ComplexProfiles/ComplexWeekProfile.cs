using AutoMapper;
using Happy.Domain.Entities;
using Happy.Service.Dtos;
using Happy.Service.Dtos.Complexes;

namespace Happy.WebApi.Mapping;

public class ComplexWeekProfile : Profile
{
    public ComplexWeekProfile()
    {
        CreateMap<ComplexWeek, ComplexWeekDto>()
            .ForMember(dest => dest.WeekDto, opt => opt.MapFrom(src => src.Week));

        CreateMap<ComplexWeekDto, ComplexWeek>()
            .ForMember(dest => dest.Week, opt => opt.MapFrom(src => src.WeekDto))
            .ForMember(dest => dest.WeekId, opt => opt.MapFrom(src => src.WeekDto.Id));
    }
}
