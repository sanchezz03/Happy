using Happy.Service.Dtos.Complexes;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IComplexWeekDataProvider
{
    Task CreateAsync(long complexId, ComplexWeekDto dto);
    Task DeleteAsync(long complexId, long weekId);
}
