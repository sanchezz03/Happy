using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;
using Happy.Infrastructure.Specification.ProgressSpecifications;

namespace Happy.Infrastructure.Repositories;

public class ProgressRepository : BaseRelationalRepository<Progress>
{
    public ProgressRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        
    }

    public async Task<IEnumerable<Progress>> GetListByUserId(string userId)
    {
        var specification = new ProgressesByUserIdSpecification(userId);
        var entities = await FindBySpecificationAsync(specification);
        return entities;
    }
}
