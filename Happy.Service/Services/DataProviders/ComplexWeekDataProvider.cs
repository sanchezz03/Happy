using AutoMapper;
using Happy.Domain.Entities;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class ComplexWeekDataProvider : IComplexWeekDataProvider
{
    private readonly ComplexWeekRepository _complexWeekRepository;
    private readonly IMapper _mapper;

    public ComplexWeekDataProvider(ComplexWeekRepository complexWeekRepository,
        IMapper mapper)
    {
        _complexWeekRepository = complexWeekRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task CreateAsync(long complexId, ComplexWeekDto dto)
    {
        var complexWeek = _mapper.Map<ComplexWeek>(dto);
        complexWeek.ComplexId = complexId;

        await _complexWeekRepository.UpdateAsync(complexWeek);
    }

    public async Task DeleteAsync(long complexId, long weekId)
    {
        var complexWeek = await _complexWeekRepository.GetByComplexIdAndWeekIdAsync(complexId, weekId);

        await _complexWeekRepository.DeleteByIdAsync(complexWeek.Id);
    }

    #endregion
}
