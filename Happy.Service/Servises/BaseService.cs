using AutoMapper;
using Happy.Domain.Repositories.Interfaces;
using Happy.Service.Servises.Interfaces;

namespace Happy.Service.Servises;

public class BaseService<TDto,KEntity> : IBaseService<TDto, KEntity> where TDto : class where KEntity : class
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<KEntity> _repository;
    private readonly IMapper _mapper;

    public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _repository = _unitOfWork.GetRepository<KEntity>();
        _mapper = mapper;
    }

    #region Public methods

    public async Task AddAsync(TDto dto)
    {
        var entity = _mapper.Map<KEntity>(dto);
        await _repository.AddAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task DeleteAsync(TDto dto)
    {
        var entity = _mapper.Map<KEntity>(dto);
        await _repository.DeleteAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    public async Task<IEnumerable<TDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        if (!entities.Any())
        {
            return new List<TDto>();
        }

        return _mapper.Map<IEnumerable<TDto>>(entities);
    }

    public async Task<TDto> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return _mapper.Map<TDto>(entity);
    }

    public async Task UpdateAsync(TDto dto)
    {
        var entity = _mapper.Map<KEntity>(dto);
        await _repository.UpdateAsync(entity);
        await _unitOfWork.CommitAsync();
    }

    #endregion
}
