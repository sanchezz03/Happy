using Happy.Service.Dtos;
using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;

namespace Happy.Service.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseDataProvider _exerciseDataProvider;

    public ExerciseService(IExerciseDataProvider exerciseDataProvider)
    {
        _exerciseDataProvider = exerciseDataProvider;
    }

    #region Public methods

    public async Task<ExerciseDto> CreateAsync(ExerciseDto exerciseDto)
    {
        return await _exerciseDataProvider.CreateAsync(exerciseDto);
    }

    public async Task<List<ExerciseDto>> GetListAsync()
    {
        return await _exerciseDataProvider.GetListAsync();
    }

    public async Task<ExerciseDto> GetAsync(string name)
    {
        return await _exerciseDataProvider.GetByNameAsync(name);
    }

    public async Task UpdateAsync(long id, ExerciseDto exerciseDto)
    {
        await _exerciseDataProvider.UpdateAsync(id, exerciseDto);
    }

    public async Task DeleteAsync(long id)
    {
        await _exerciseDataProvider.DeleteByIdAsync(id);
    }

    #endregion
}
