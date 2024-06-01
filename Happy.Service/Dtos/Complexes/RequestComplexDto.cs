using Happy.Common.Enums;

namespace Happy.Service.Dtos.Complexes;

public class RequestComplexDto 
{
    public string Name { get; set; }
    public int? TotalSets { get; set; }
    public TimeSpan? Duration { get; set; }
    public EWeekDay WeekDay { get; set; }
    public List<string> ExerciseNames { get; set; }
    public int WeekNumber { get; set; }
}
