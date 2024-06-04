using Happy.Service.Services.DataProviders.Interfaces;
using Happy.Service.Services.Interfaces;
using Happy.Service.Dtos.Complexes;
using AutoMapper;
using Happy.Service.Dtos;

namespace Happy.Service.Services;

public class ComplexService : IComplexService
{
    private readonly IComplexDataProvider _complexDataProvider;
    private readonly IExerciseDataProvider _exerciseDataProvider;
    private readonly IWeekDataProvider _weekDataProvider;
    private readonly IMapper _mapper;

    public ComplexService(IComplexDataProvider complexDataProvider,
        IExerciseDataProvider exerciseDataProvider,
        IWeekDataProvider weekDataProvider,
        IMapper mapper)
    {
        _complexDataProvider = complexDataProvider;
        _exerciseDataProvider = exerciseDataProvider;
        _weekDataProvider = weekDataProvider;
        _mapper = mapper;
    }

    #region Public methods

    public async Task<ComplexDto> CreateAsync(RequestComplexDto dto)
    {
        var modificationComplexDto = await GetComplexDtoAsync(dto);

        var complexDto = await _complexDataProvider.CreateAsync(modificationComplexDto);
        if (complexDto == null)
        {
            return new ComplexDto();
        }

        return complexDto;
    }

    public async Task<IEnumerable<ComplexDto>> GetListAsync(int weekNumber)
    {
        return await _complexDataProvider.GetListAsync(weekNumber);
    }

    public async Task DeleteAsync(long id)
    {
        await _complexDataProvider.DeleteByIdAsync(id);
    }

    #endregion

    #region Private methods

    private async Task<ModificationComplexDto> GetComplexDtoAsync(RequestComplexDto dto)
    {
        var modificationComplexDto = _mapper.Map<ModificationComplexDto>(dto);
        modificationComplexDto.ComplexExerciseDtos = await HandleFillingExercisesAsync(dto.ExerciseNames);
        modificationComplexDto.ComplexWeekDtos = await HandleFillingWeeksAsync(dto.WeekNumber);

        return modificationComplexDto;
    }

    private async Task<List<ComplexExerciseDto>> HandleFillingExercisesAsync(List<string> exerciseNames)
    {
        var complexExerciseDtos = new List<ComplexExerciseDto>();
        var exerciseDtos = await _exerciseDataProvider.GetListByNames(exerciseNames);
        if (!exerciseDtos.Any())
        {
            throw new Exception($"There are no exercises by provided names: {exerciseNames}");
        }

        foreach (var exerciseDto in exerciseDtos)
        {
            var complexExerciseDto = GetComplexExerciseDto(exerciseDto);
            complexExerciseDtos.Add(complexExerciseDto);
        }

        return complexExerciseDtos;
    }

    private ComplexExerciseDto GetComplexExerciseDto(ExerciseDto exerciseDto)
    {
        return new ComplexExerciseDto()
        {
            ExerciseDto = exerciseDto
        };
    }

    private async Task<List<ComplexWeekDto>> HandleFillingWeeksAsync(int weekNumber)
    {
        var weekDto = await _weekDataProvider.GetByWeekNumberAsync(weekNumber);

        return new List<ComplexWeekDto>()
        {
            new ComplexWeekDto()
            {
                WeekDto = weekDto
            }
        };
    }

    #endregion
}
