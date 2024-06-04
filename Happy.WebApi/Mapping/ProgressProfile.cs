using AutoMapper;
using Happy.Common.Helpers;
using Happy.Domain.Entities;
using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;

namespace Happy.WebApi.Mapping;

public class ProgressProfile : Profile
{
    public ProgressProfile()
    {
        CreateMap<ModificationProgressDto, Progress>()
            .ForMember(dest => dest.Exercise, opt => opt.Ignore())
            .ForMember(dest => dest.User, opt => opt.Ignore());

        CreateMap<Progress, ProgressDto>()
            .ForMember(dest => dest.RateOfPerceivedExertion, opt => opt.MapFrom(src => src.RateOfPerceivedExertion.Value.ToDisplayText()));
    }
}
