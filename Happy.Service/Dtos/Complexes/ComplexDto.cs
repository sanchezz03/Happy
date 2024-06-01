using Happy.Common.Enums;

namespace Happy.Service.Dtos.Complexes;

public class ComplexDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public int? TotalSets { get; set; }
    public TimeSpan? Duration { get; set; }
    public EWeekDay WeekDay { get; set; }
    public List<ComplexExerciseDto> ComplexExerciseDtos { get; set; } = new List<ComplexExerciseDto>();
    public List<ComplexWeekDto> ComplexWeekDtos { get; set; } = new List<ComplexWeekDto>(); 
}
