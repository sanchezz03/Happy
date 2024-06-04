using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;
using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;

namespace Happy.Service.Services;

public class ProgressService : IProgressService
{
    private readonly IProgressDataProvider _progressDataProvider;
    private readonly IExerciseDataProvider _exerciseDataProvider;

    public ProgressService(IProgressDataProvider progressDataProvider, IExerciseDataProvider exerciseDataProvider)
    {
        _progressDataProvider = progressDataProvider;
        _exerciseDataProvider = exerciseDataProvider;
    }

    #region Public methods

    public async Task<ProgressDto> CreateAsync(string userId,ModificationProgressDto modificationProgressDto)
    {
        var exerciseDto = await _exerciseDataProvider.GetByNameAsync(modificationProgressDto.ExerciseName);
        if (exerciseDto == null)
        {
            return new ProgressDto();
        }

        return await _progressDataProvider.CreateAsync(userId, exerciseDto.Id, modificationProgressDto);
    }

    public async Task<IEnumerable<ProgressDto>> GetListAsync(string userId)
    {
        return await _progressDataProvider.GetListAsync(userId);
    }

    public async Task UpdateAsync(long id, ModificationProgressDto modificationProgressDto)
    {
        await _progressDataProvider.UpdateAsync(id, modificationProgressDto);
    }

    public async Task DeleteAsync(long id)
    {
        await _progressDataProvider.DeleteByIdAsync(id);
    }

    #endregion
}
