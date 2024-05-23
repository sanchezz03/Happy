using Happy.Domain.Entities;

namespace Happy.Domain.Repositories;

public interface IRepository<T, K> where T : Base<K>
{
    Task<T?> GetAsync(K id, bool isAsNoTracking = true);
    Task<IEnumerable<T>> GetListAsync(bool isAsNoTracking = true);
    Task<K> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task DeleteByIdAsync(K id);
}
