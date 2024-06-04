using Happy.Service.Dtos.Complexes;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IComplexDataProvider
{
    Task<ComplexDto> CreateAsync(ModificationComplexDto dto);
    Task<IEnumerable<ComplexDto>> GetListAsync(int weekNumber);
    Task<ComplexDto> GetAsync(long id);
    Task UpdateAsync(long id, ComplexDto complexDto);
    Task DeleteByIdAsync(long id);
}
