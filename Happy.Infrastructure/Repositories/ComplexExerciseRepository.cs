using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.ComplexSpecifications;

namespace Happy.Infrastructure.Repositories;

public class ComplexExerciseRepository : BaseRelationalRepository<ComplexExercise>
{
    public ComplexExerciseRepository(AppDbContext appDbContext)
    : base(appDbContext) { }

    public async Task<ComplexExercise> GetByComplexIdAndExerciseIdAsync(long complexId, long exerciseId)
    {
        var specification = new ComplexExerciseByComplexIdAndExerciseIdSpecification(complexId, exerciseId);
        var entities = await FindBySpecificationAsync(specification);
        var entity = entities.FirstOrDefault(ce => ce.ComplexId == complexId && ce.ExerciseId == exerciseId);
        return entity;
    }
}
