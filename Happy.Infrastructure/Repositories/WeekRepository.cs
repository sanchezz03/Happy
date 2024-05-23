using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.WeekSpecifications;

namespace Happy.Infrastructure.Repositories;

public class WeekRepository : BaseRelationalRepository<Week>
{
    public WeekRepository(AppDbContext appDbContext)
        : base(appDbContext) { }

    public async Task<Week> GetByWeekNumber(int weekNumber)
    {
        var specification = new WeekByNumberSpecification(weekNumber);
        var entities = await FindBySpecificationAsync(specification);
        var week = entities.FirstOrDefault(w => w.WeekNumber == weekNumber);
        return week;
    }
}
