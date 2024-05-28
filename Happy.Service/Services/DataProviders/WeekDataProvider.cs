using AutoMapper;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class WeekDataProvider : IWeekDataProvider
{
    private readonly WeekRepository _weekRepository;
    private readonly IMapper _mapper;

    public WeekDataProvider(WeekRepository weekRepository, IMapper mapper)
    {
        _weekRepository = weekRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task<WeekDto> GetByWeekNumberAsync(int weekNumber)
    {
        var entity = await _weekRepository.GetByWeekNumberAsync(weekNumber);

        return _mapper.Map<WeekDto>(entity);
    }

    #endregion
}
