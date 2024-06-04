using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ProgressSpecifications;

public class ProgressesByUserIdSpecification : BaseSpecification<Progress>
{
    public ProgressesByUserIdSpecification(string userId)
        : base(p => p.UserId.Contains(userId))
    {
        AddInclude("Exercise");
    }
}
