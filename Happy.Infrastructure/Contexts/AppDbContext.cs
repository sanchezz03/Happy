using Happy.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Happy.Infrastructure.Contexts;

public class AppDbContext : IdentityDbContext<User>
{
    #region Entities DbSet

    public DbSet<User> Users { get; set; }
    public DbSet<Week> Weeks { get; set; }

    #endregion

    public AppDbContext(DbContextOptions options) : base(options) { }

    #region Protected methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    #endregion
}
