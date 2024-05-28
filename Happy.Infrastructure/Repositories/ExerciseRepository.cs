using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.ExerciseSpecifications;

namespace Happy.Infrastructure.Repositories;

public class ExerciseRepository : BaseRelationalRepository<Exercise>
{
    public ExerciseRepository(AppDbContext appDbContext)
        : base(appDbContext) { }

    public async Task<Exercise> GetByExerciseNameAsync(string exerciseName)
    {
        var specification = new ExerciseByNameSpecification(exerciseName);
        var entities = await FindBySpecificationAsync(specification);
        var exercise = entities.FirstOrDefault(e => e.Name.Equals(exerciseName));
        return exercise;
    }
}
