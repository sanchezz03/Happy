using Happy.Domain.Entities;
using Happy.Infrastructure.Contexts;

namespace Happy.Infrastructure.Repositories;

public class ProgressRepository : BaseRelationalRepository<Progress>
{
    public ProgressRepository(AppDbContext appDbContext)
        : base(appDbContext)
    {
        
    }
}
