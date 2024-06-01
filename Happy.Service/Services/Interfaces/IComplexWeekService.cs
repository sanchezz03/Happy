namespace Happy.Service.Services.Interfaces;

public interface IComplexWeekService
{
    Task CreateAsync(long complexId, int weekNumber);
    Task DeleteAsync(long complexId, int weekNumber);
}
