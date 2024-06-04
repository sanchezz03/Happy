using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IProgressDataProvider
{
    Task<ProgressDto> CreateAsync(string userId, long exerciseId, ModificationProgressDto progressDto);
    Task<IEnumerable<ProgressDto>> GetListAsync(string userId);
    Task UpdateAsync(long id, ModificationProgressDto progressDto);
    Task DeleteByIdAsync(long id);
}
