using AutoMapper;
using Happy.Domain.Entities;
using Happy.Infrastructure.Repositories;
using Happy.Service.Dtos.Complexes;
using Happy.Service.Services.DataProviders.Interfaces;

namespace Happy.Service.Services.DataProviders;

public class ComplexDataProvider : IComplexDataProvider
{
    private readonly ComplexRepository _complexRepository;
    private readonly IMapper _mapper;

    public ComplexDataProvider(ComplexRepository complexRepository,
        IMapper mapper)
    {
        _complexRepository = complexRepository;
        _mapper = mapper;
    }

    #region Public methods

    public async Task<ComplexDto> CreateAsync(ModificationComplexDto dto)
    {
        var complex = _mapper.Map<Complex>(dto);

        complex.Id = await _complexRepository.AddAsync(complex);

        await HandleAddingRelatedEntities(complex, dto);

        var response = await _complexRepository.GetByIdAsync(complex.Id);

        return _mapper.Map<ComplexDto>(response);
    }

    #region PPP
    public async Task<IEnumerable<ComplexDto>> GetListAsync(int weekNumber)
    {
        var entities = await _complexRepository.GetListByWeekNumberAsync(weekNumber);

        return _mapper.Map<IEnumerable<ComplexDto>>(entities);
    }

    public async Task<ComplexDto> GetAsync(long id)
    {
        var complex = await GetByIdAsync(id);

        return _mapper.Map<ComplexDto>(complex);
    }

    public async Task UpdateAsync(long id, ComplexDto complexDto)
    {
        var complex = _mapper.Map<Complex>(complexDto);
       
        await _complexRepository.UpdateAsync(complex);
    }
    #endregion
    public async Task DeleteByIdAsync(long id)
    {
        var complex = await GetByIdAsync(id);

        await _complexRepository.DeleteAsync(complex);
    }

    #endregion

    #region Private methods

    private async Task<Complex> GetByIdAsync(long id)
    {
        var complex = await _complexRepository.GetByIdAsync(id);

        if (complex == null)
        {
            throw new Exception($"Complex not found for id: {id}");
        }

        return complex;
    }

    private async Task HandleAddingRelatedEntities(Complex complex, ModificationComplexDto dto)
    {
        complex.ComplexExercises = GetComplexExercises(complex.Id, dto);
        complex.ComplexWeeks = GetComplexWeeks(complex.Id, dto);

        await _complexRepository.UpdateAsync(complex);
    }

    private List<ComplexExercise> GetComplexExercises(long complexId, ModificationComplexDto dto)
    {
        var complexExercises = new List<ComplexExercise>();

        foreach (var complexExerciseDto in dto.ComplexExerciseDtos)
        {
            complexExercises.Add(new ComplexExercise
            {
                ComplexId = complexId,
                ExerciseId = complexExerciseDto.ExerciseDto.Id
            });
        }

        return complexExercises;
    }

    private List<ComplexWeek> GetComplexWeeks(long complexId, ModificationComplexDto dto)
    {
        var complexWeeks = new List<ComplexWeek>();

        foreach (var complexWeekDto in dto.ComplexWeekDtos)
        {
            complexWeeks.Add(new ComplexWeek
            {
                ComplexId = complexId,
                WeekId = complexWeekDto.WeekDto.Id
            });
        }

        return complexWeeks;
    }

    #endregion
}
