using Happy.Service.Dtos;

namespace Happy.Service.Services.Interfaces;

public interface IExerciseService
{
    Task<ExerciseDto> CreateAsync(ExerciseDto exerciseDto);
    Task<ExerciseDto> GetAsync(string name);
    Task UpdateAsync(long id, ExerciseDto exerciseDto);
    Task DeleteAsync(long id);
}
