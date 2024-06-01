using Happy.Service.Dtos.Complexes;

namespace Happy.Service.Services.Interfaces;

public interface IComplexService
{
    Task<ComplexDto> CreateAsync(RequestComplexDto dto);
    Task<IEnumerable<ComplexDto>> GetListAsync(int weekNumber);
    Task DeleteAsync(long id);
}
