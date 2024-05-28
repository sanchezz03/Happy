using Happy.Service.Dtos;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IExerciseDataProvider
{
    Task<ExerciseDto> CreateAsync(ExerciseDto exerciseDto);
    Task<ExerciseDto> GetByNameAsync(string name);
    Task UpdateAsync(long id, ExerciseDto exerciseDto);
    Task DeleteByIdAsync(long id);
}
