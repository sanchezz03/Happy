using AutoMapper;
using Happy.Domain.Entities;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class ComplexExerciseDataProvider : IComplexExerciseDataProvider
{
    private readonly ComplexExerciseRepository _complexExerciseRepository;
    private readonly IMapper _mapper;

    public ComplexExerciseDataProvider(ComplexExerciseRepository complexExerciseRepository,
        IMapper mapper)
    {
        _complexExerciseRepository = complexExerciseRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task CreateAsync(long complexId, ComplexExerciseDto dto)
    {
        var complexExercise = _mapper.Map<ComplexExercise>(dto);
        complexExercise.ComplexId = complexId;

        await _complexExerciseRepository.UpdateAsync(complexExercise);
    }

    public async Task DeleteAsync(long complexId, long exerciseId)
    {
        var complexExercise = await _complexExerciseRepository.GetByComplexIdAndExerciseIdAsync(complexId, exerciseId);

        await _complexExerciseRepository.DeleteByIdAsync(complexExercise.Id);
    }

    #endregion
}
