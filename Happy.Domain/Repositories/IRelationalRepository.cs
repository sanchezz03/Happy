using Happy.Domain.Entities;
using Happy.Domain.Specifications;

namespace Happy.Domain.Repositories;

public interface IRelationalRepository<T> : IRepository<T, long> where T : Base<long>
{
    Task DeleteAsync(T entity);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task<ICollection<T>> FindBySpecificationAsync(ISpecification<T> specification);
}
