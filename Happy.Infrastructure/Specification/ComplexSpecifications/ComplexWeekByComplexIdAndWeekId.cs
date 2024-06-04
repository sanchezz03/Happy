using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ComplexSpecifications;

public class ComplexWeekByComplexIdAndWeekId : BaseSpecification<ComplexWeek>
{
    public ComplexWeekByComplexIdAndWeekId(long complexId, long weekId)
        : base(cw => cw.ComplexId == complexId && cw.WeekId == weekId)
    {

    }
}
