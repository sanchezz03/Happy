using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class WeekConfiguration : IEntityTypeConfiguration<Week>
{
    public void Configure(EntityTypeBuilder<Week> builder)
    {
        builder
            .ToTable("Weeks")
            .HasKey(t => t.Id);

        builder
            .Property(t => t.StartDate)
            .IsRequired();

        builder
            .Property(t => t.EndDate)
            .IsRequired();

        builder
            .Property(t => t.Year)
            .IsRequired();

        builder
            .Property(t => t.WeekNumber)
            .IsRequired();

        #region Navigation property

        builder
            .HasMany(w => w.ComplexWeeks)
            .WithOne(w => w.Week)
            .HasForeignKey(w => w.WeekId);

        #endregion
    }
}
