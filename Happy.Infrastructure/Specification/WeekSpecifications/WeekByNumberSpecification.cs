using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.WeekSpecifications;

public class WeekByNumberSpecification : BaseSpecification<Week>
{
    public WeekByNumberSpecification(int weekNumber)
        : base(w => w.WeekNumber == weekNumber)
    {    
    }
}
