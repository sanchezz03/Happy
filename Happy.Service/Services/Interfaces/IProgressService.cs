using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;

namespace Happy.Service.Services.Interfaces;

public interface IProgressService
{
    Task<ProgressDto> CreateAsync(ModificationProgressDto modificationProgressDto);
    Task<IEnumerable<ProgressDto>> GetListAsync(string userId);
    Task UpdateAsync(long id, ModificationProgressDto modificationProgressDto);
    Task DeleteAsync(long id);
}
