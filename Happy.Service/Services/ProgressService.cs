using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;
using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;

namespace Happy.Service.Services;

public class ProgressService : IProgressService
{
    private readonly IProgressDataProvider _progressDataProvider;

    public ProgressService(IProgressDataProvider progressDataProvider)
    {
        _progressDataProvider = progressDataProvider;
    }

    #region Public methods

    public async Task<ProgressDto> CreateAsync(ModificationProgressDto modificationProgressDto)
    {
        return await _progressDataProvider.CreateAsync(modificationProgressDto);
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
