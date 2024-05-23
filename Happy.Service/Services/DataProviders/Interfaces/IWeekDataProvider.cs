using Happy.Service.Dtos;

namespace Happy.Service.Services.DataProviders.Interfaces;

public interface IWeekDataProvider
{ 
    Task<WeekDto> GetByWeekNumber(int weekNumber);  
}
