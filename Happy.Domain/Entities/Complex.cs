using Happy.Common.Enums;

namespace Happy.Domain.Entities;

public class Complex : Base<long>
{
    public string Name { get; set; }
    public int? TotalSets { get; set; }
    public TimeSpan? Duration { get; set; }
    public EWeekDay WeekDay { get; set; }

    #region Navigation properties

    public ICollection<ComplexExercise> ComplexExercises { get; set; } = new List<ComplexExercise>();
    public ICollection<ComplexWeek> ComplexWeeks { get; set; } = new List<ComplexWeek>();

    #endregion
}
