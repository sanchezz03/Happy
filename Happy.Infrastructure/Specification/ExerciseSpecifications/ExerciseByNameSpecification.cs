using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ExerciseSpecifications;

public class ExerciseByNameSpecification : BaseSpecification<Exercise>
{
    public ExerciseByNameSpecification(string exerciseName)
        : base(e => e.Name.ToLower().Equals(exerciseName.ToLower()))
    {   
    }
}
