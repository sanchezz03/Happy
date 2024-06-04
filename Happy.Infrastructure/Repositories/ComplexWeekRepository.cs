using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.ComplexSpecifications;

namespace Happy.Infrastructure.Repositories;

public class ComplexWeekRepository : BaseRelationalRepository<ComplexWeek>
{
    public ComplexWeekRepository(AppDbContext appDbContext)
        : base(appDbContext) { }

    public async Task<ComplexWeek> GetByComplexIdAndWeekIdAsync(long complexId, long weekId)
    {
        var specification = new ComplexWeekByComplexIdAndWeekId(complexId, weekId);
        var entities = await FindBySpecificationAsync(specification);
        var entity = entities.FirstOrDefault(cw => cw.ComplexId == complexId && cw.WeekId == weekId);
        return entity;
    }
}
