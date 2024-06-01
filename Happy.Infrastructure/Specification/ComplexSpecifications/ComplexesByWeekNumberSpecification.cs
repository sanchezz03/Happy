using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ComplexSpecifications;

public class ComplexesByWeekNumberSpecification : BaseSpecification<Complex>
{
    public ComplexesByWeekNumberSpecification(int weekNumber)
        : base(c => c.ComplexWeeks.Any(x => x.Week.WeekNumber == weekNumber))
    {
        AddInclude(c => c.ComplexExercises);
        AddInclude("ComplexExercises.Exercise");
        AddInclude(c => c.ComplexWeeks);
        AddInclude("ComplexWeeks.Week");
    }
}
