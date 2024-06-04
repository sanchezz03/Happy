using AutoMapper;
using Happy.Domain.Entities;
using Happy.Service.Dtos.Complexes;

namespace Happy.WebApi.Mapping;

public class ComplexExerciseProfile : Profile
{
    public ComplexExerciseProfile()
    {
        CreateMap<ComplexExercise, ComplexExerciseDto>()
                   .ForMember(dest => dest.ExerciseDto, opt => opt.MapFrom(src => src.Exercise));

        CreateMap<ComplexExerciseDto, ComplexExercise>()
            .ForMember(dest => dest.Exercise, opt => opt.MapFrom(src => src.ExerciseDto))
            .ForMember(dest => dest.ExerciseId, opt => opt.MapFrom(src => src.ExerciseDto.Id));
    }
}
