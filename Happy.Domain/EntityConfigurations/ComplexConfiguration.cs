using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class ComplexConfiguration : IEntityTypeConfiguration<Complex>
{
    public void Configure(EntityTypeBuilder<Complex> builder)
    {
        builder
            .ToTable("Complexes")
            .HasKey(c => c.Id);

        builder
            .Property(c => c.Name)
            .IsRequired();

        builder
           .Property(c => c.TotalSets)
           .IsRequired(false);

        builder
            .Property(c => c.Duration)
            .IsRequired(false);

        builder
            .Property(c => c.WeekDay)
            .IsRequired();

        #region Navigation properties

        builder
            .HasMany(c => c.ComplexExercises)
            .WithOne(c => c.Complex)
            .HasForeignKey(c => c.ComplexId);

        builder
            .HasMany(c => c.ComplexWeeks)
            .WithOne(c => c.Complex)
            .HasForeignKey(c => c.ComplexId);

        #endregion
    }
}
