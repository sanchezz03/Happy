using Happy.Service.Dtos;
using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;

namespace Happy.Service.Services;

public class ComplexWeekService : IComplexWeekService
{
    private readonly IComplexWeekDataProvider _complexWeekDataProvider;
    private readonly IWeekDataProvider _weekDataProvider;
    private readonly IComplexDataProvider _complexDataProvider;

    public ComplexWeekService(IComplexWeekDataProvider complexWeekDataProvider,
        IWeekDataProvider weekDataProvider,
        IComplexDataProvider complexDataProvider)
    {
        _complexWeekDataProvider = complexWeekDataProvider;
        _weekDataProvider = weekDataProvider;
        _complexDataProvider = complexDataProvider;
    }

    #region Public methods

    public async Task CreateAsync(long complexId, int weekNumber)
    {
        var complexDto = await _complexDataProvider.GetAsync(complexId);
        var weekDto = await GetWeekDtoAsync(weekNumber);

        var complexWeekDto = GetComplexWeekDto(weekDto);
        await _complexWeekDataProvider.CreateAsync(complexDto.Id, complexWeekDto);
    }

    public async Task DeleteAsync(long complexId, int weekNumber)
    {
        var weekDto = await GetWeekDtoAsync(weekNumber);
        
        await _complexWeekDataProvider.DeleteAsync(complexId, weekDto.Id);
    }

    #endregion

    #region Private methods

    private ComplexWeekDto GetComplexWeekDto(WeekDto weekDto)
    {
        return new ComplexWeekDto()
        {
            WeekDto = weekDto,
        };
    }

    private async Task<WeekDto> GetWeekDtoAsync(int weekNumber)
    {
        return await _weekDataProvider.GetByWeekNumberAsync(weekNumber);
    }

    #endregion
}
