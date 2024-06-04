using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.ComplexSpecifications;

namespace Happy.Infrastructure.Repositories;

public class ComplexRepository : BaseRelationalRepository<Complex>
{
    public ComplexRepository(AppDbContext appDbContext)
        : base(appDbContext) { }

    public async Task<IEnumerable<Complex>> GetListByWeekNumberAsync(int weekNumber)
    {
        var specification = new ComplexesByWeekNumberSpecification(weekNumber);
        var entities = await FindBySpecificationAsync(specification);
        return entities;
    }

    public async Task<Complex> GetByIdAsync(long id)
    {
        var specification = new ComplexesByIdSpecification(id);
        var entities = await FindBySpecificationAsync(specification);
        var entity = entities.FirstOrDefault(e => e.Id == id);
        return entity;
    }
}
