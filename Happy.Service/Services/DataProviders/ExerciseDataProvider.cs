using AutoMapper;
using Happy.Domain.Entities;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class ExerciseDataProvider : IExerciseDataProvider
{
    private readonly ExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public ExerciseDataProvider(ExerciseRepository exerciseRepository, IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task<ExerciseDto> CreateAsync(ExerciseDto dto)
    {
        var entity = _mapper.Map<Exercise>(dto);

        var id = await _exerciseRepository.AddAsync(entity);

        var response = await _exerciseRepository.GetAsync(id);

        return _mapper.Map<ExerciseDto>(response);
    }

    public async Task<IEnumerable<ExerciseDto>> GetListByNames(List<string> exerciseNames)
    {
        var entities = await _exerciseRepository.GetListByExerciseNamesAsync(exerciseNames);
        
        if (entities == null || !entities.Any())
        {
            return new List<ExerciseDto>(); 
        }

        return _mapper.Map<IEnumerable<ExerciseDto>>(entities);
    }

    public async Task<List<ExerciseDto>> GetListAsync()
    {
        var entities = await _exerciseRepository.GetListAsync();

        return _mapper.Map<List<ExerciseDto>>(entities);    
    }

    public async Task<ExerciseDto> GetByNameAsync(string name)
    {
        var entity = await _exerciseRepository.GetByExerciseNameAsync(name);

        return _mapper.Map<ExerciseDto>(entity);
    }

    public async Task UpdateAsync(long id, ExerciseDto dto)
    {
        var exercise = await GetByIdAsync(id);

        exercise = _mapper.Map<Exercise>(dto);

        exercise.Id = id;

        await _exerciseRepository.UpdateAsync(exercise);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var exercise = await GetByIdAsync(id);

        await _exerciseRepository.DeleteAsync(exercise);
    }

    #endregion

    #region Private methods

    private async Task<Exercise> GetByIdAsync(long id)
    {
        var exercise = await _exerciseRepository.GetAsync(id);

        if (exercise == null)
        {
            throw new Exception($"Exercise not found for id: {id}");
        }

        return exercise;
    }

    #endregion
}
