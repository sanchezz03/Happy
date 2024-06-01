using AutoMapper;
using Happy.Domain.Entities;
using Happy.Service.Dtos;
using Happy.Service.Dtos.Complexes;

namespace Happy.WebApi.Mapping;

public class ComplexProfile : Profile
{
    public ComplexProfile()
    {
        CreateMap<Complex, ComplexDto>()
           .ForMember(dest => dest.ComplexExerciseDtos, opt => opt.MapFrom(src => src.ComplexExercises))
           .ForMember(dest => dest.ComplexWeekDtos, opt => opt.MapFrom(src => src.ComplexWeeks));

        CreateMap<ComplexDto, Complex>()
            .ForMember(dest => dest.ComplexExercises, opt => opt.MapFrom(src => src.ComplexExerciseDtos))
            .ForMember(dest => dest.ComplexWeeks, opt => opt.MapFrom(src => src.ComplexWeekDtos));

        CreateMap<RequestComplexDto, ModificationComplexDto>()
            .ForMember(dest => dest.ComplexExerciseDtos, opt => opt.Ignore())
            .ForMember(dest => dest.ComplexExerciseDtos, opt => opt.Ignore());

        CreateMap<ModificationComplexDto, Complex>()
            .ForMember(dest => dest.ComplexExercises, opt => opt.Ignore())
            .ForMember(dest => dest.ComplexWeeks, opt => opt.Ignore());
    }
}
