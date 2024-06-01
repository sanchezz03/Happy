using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ComplexSpecifications;

public class ComplexExerciseByComplexIdAndExerciseIdSpecification : BaseSpecification<ComplexExercise>
{
    public ComplexExerciseByComplexIdAndExerciseIdSpecification(long complexId, long exerciseId)
        : base(ce => ce.ComplexId == complexId && ce.ExerciseId == exerciseId)
    {
        
    }
}
