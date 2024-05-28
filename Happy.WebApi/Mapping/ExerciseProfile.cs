using AutoMapper;
using Happy.Domain.Entities;
using Happy.Service.Dtos;

namespace Happy.WebApi.Mapping;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<ExerciseDto, Exercise>();

        CreateMap<Exercise, ExerciseDto>();
    }
}
