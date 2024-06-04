using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ExerciseSpecifications;

public class ExercisesByNamesSpecification : BaseSpecification<Exercise>
{
    public ExercisesByNamesSpecification(List<string> exerciseNames)
        : base(e => exerciseNames.Contains(e.Name))
    {
        
    }
}
