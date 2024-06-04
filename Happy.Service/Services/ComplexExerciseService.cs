using Happy.Service.Dtos;
using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;

namespace Happy.Service.Services;

public class ComplexExerciseService : IComplexExerciseService
{
    private readonly IComplexExerciseDataProvider _complexExerciseDataProvider;
    private readonly IExerciseDataProvider _exerciseDataProvider;
    private readonly IComplexDataProvider _complexDataProvider;

    public ComplexExerciseService(IComplexExerciseDataProvider complexExerciseDataProvider,
        IExerciseDataProvider exerciseDataProvider, 
        IComplexDataProvider complexDataProvider
        )
    {
        _complexExerciseDataProvider = complexExerciseDataProvider;
        _exerciseDataProvider = exerciseDataProvider;
        _complexDataProvider = complexDataProvider;
    }

    #region Public methods

    public async Task CreateAsync(long complexId, string exerciseName)
    {
        var complexDto = await _complexDataProvider.GetAsync(complexId);
        var exerciseDto = await GetExerciseDtoAsync(exerciseName);

        var complexExerciseDto = GetComplexExerciseDto(exerciseDto);
        await _complexExerciseDataProvider.CreateAsync(complexDto.Id, complexExerciseDto);
    }

    public async Task DeleteAsync(long complexId, string exerciseName)
    {
        var exerciseDto = await GetExerciseDtoAsync(exerciseName);

        await _complexExerciseDataProvider.DeleteAsync(complexId, exerciseDto.Id);
    }

    #endregion

    #region Private methods

    private ComplexExerciseDto GetComplexExerciseDto(ExerciseDto exerciseDto)
    {
        return new ComplexExerciseDto()
        {
            ExerciseDto = exerciseDto
        };
    }

    private async Task<ExerciseDto> GetExerciseDtoAsync(string exerciseName)
    {
        var exerciseDto = await _exerciseDataProvider.GetByNameAsync(exerciseName);
        if (exerciseDto == null)
        {
            throw new Exception($"Can't find exercise by name: {exerciseName}");
        }

        return exerciseDto;
    }

    #endregion
}
