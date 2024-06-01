using Happy.Service.Dtos;
using Happy.Service.Dtos.Complexes;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IComplexExerciseDataProvider
{
    Task CreateAsync(long complexId, ComplexExerciseDto dto);
    Task DeleteAsync(long complexId, long exerciseId);
}
