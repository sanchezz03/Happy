using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
{
    public void Configure(EntityTypeBuilder<Exercise> builder)
    {
        builder
            .ToTable("Exericeses")
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Name)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .IsRequired();

        builder
            .Property(e => e.Weight)
            .IsRequired(false);

        builder
            .Property(e => e.NumberOfRepetitions)
            .IsRequired();

        #region Navigation properties

        builder
            .HasMany(e => e.ComplexExercises)
            .WithOne(e => e.Exercise)
            .HasForeignKey(e => e.ExerciseId);

        #endregion
    }
}
