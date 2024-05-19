using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Happy.Infrastructure.Contexts;

public class HappyDbContext : DbContext
{
    public DbSet<Week> Weeks { get; set; }

    public HappyDbContext(DbContextOptions options)
        : base(options)
    {

    }

    #region Protected methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }

    #endregion
}
