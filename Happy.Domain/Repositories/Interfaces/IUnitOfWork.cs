namespace Happy.Domain.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    void Dispose();
}
