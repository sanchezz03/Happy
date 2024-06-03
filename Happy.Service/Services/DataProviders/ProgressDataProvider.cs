using AutoMapper;
using Happy.Domain.Entities;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos;
using Happy.Service.Dtos.Progresses;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class ProgressDataProvider : IProgressDataProvider
{
    private readonly ProgressRepository _progressRepository;
    private readonly IMapper _mapper;

    public ProgressDataProvider(ProgressRepository progressRepository, 
        IMapper mapper)
    {
        _progressRepository = progressRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task<ProgressDto> CreateAsync(ModificationProgressDto modificationProgressDto)
    {
        var entity = _mapper.Map<Progress>(modificationProgressDto);

        var id = await _progressRepository.AddAsync(entity);

        var response = await _progressRepository.GetAsync(id);

        return _mapper.Map<ProgressDto>(response);  
    }

    public async Task<IEnumerable<ProgressDto>> GetListAsync(string userId)
    {
        var entities = await _progressRepository.GetListByUserId(userId);

        return _mapper.Map<IEnumerable<ProgressDto>>(entities);
    }

    public async Task UpdateAsync(long id, ModificationProgressDto modificationProgressDto)
    {
        var entity = await GetProgressAsync(id);

        entity = _mapper.Map<Progress>(modificationProgressDto);

        entity.Id = id;

        await _progressRepository.UpdateAsync(entity);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await GetProgressAsync(id);

        await _progressRepository.DeleteAsync(entity);  
    }

    #endregion

    #region Private methods

    private async Task<Progress> GetProgressAsync(long id)
    {
        var entity = await _progressRepository.GetAsync(id);

        if (entity == null)
        {
            throw new Exception($"Cannot get progress entity by id: {id}");
        }

        return entity;
    }

    #endregion
}
