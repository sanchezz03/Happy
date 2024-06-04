using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ComplexSpecifications;

public class ComplexesByIdSpecification : BaseSpecification<Complex>
{
    public ComplexesByIdSpecification(long id)
        : base(c => c.Id == id)
    {
        AddInclude(c => c.ComplexExercises);
        AddInclude("ComplexExercises.Exercise");
        AddInclude(c => c.ComplexWeeks);
        AddInclude("ComplexWeeks.Week");
    }
}
