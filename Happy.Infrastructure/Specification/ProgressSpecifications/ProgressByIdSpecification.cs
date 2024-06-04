using Happy.Domain.Entities;

namespace Happy.Infrastructure.Specification.ProgressSpecifications;

public class ProgressByIdSpecification : BaseSpecification<Progress>
{
    public ProgressByIdSpecification(long id)
        : base(p => p.Id == id)
    {
        AddInclude("Exercise");
    }
}
