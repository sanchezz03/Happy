using Happy.Domain.Repositories.Interfaces;
using Happy.Infrastructure.Contexts;

namespace Happy.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }

    #region Public methods

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IRepository<T> GetRepository<T>() where T : class
    {
        if (_repositories.ContainsKey(typeof(T)))
        {
            return (IRepository<T>)_repositories[typeof(T)];
        }

        var repository = new Repository<T>(_context);
        _repositories.Add(typeof(T), repository);
        return repository;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    #endregion
}
