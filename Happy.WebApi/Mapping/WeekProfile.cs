using AutoMapper;
using Happy.Domain.Entities;
using Happy.Service.Dtos;

namespace Happy.WebApi.Mapping;

public class WeekProfile : Profile
{
    public WeekProfile()
    {
        CreateMap<WeekDto, Week>();

        CreateMap<Week, WeekDto>();
    }
}
