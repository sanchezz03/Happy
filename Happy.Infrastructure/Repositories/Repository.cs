using Happy.Domain.Repositories.Interfaces;
using Happy.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Happy.Infrastructure.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly HappyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(HappyDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    #region Public methods

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public Task DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }


    #endregion
}
