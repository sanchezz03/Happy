using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class ComplexExerciseConfiguration : IEntityTypeConfiguration<ComplexExercise>
{
    public void Configure(EntityTypeBuilder<ComplexExercise> builder)
    {
        builder
            .ToTable("ComplexExercises")
            .HasKey(ce => ce.Id);

        builder
            .HasOne(ce => ce.Exercise)
            .WithMany(ce => ce.ComplexExercises)
            .HasForeignKey(ce => ce.ExerciseId);

        builder
            .HasOne(ce => ce.Complex)
            .WithMany(ce => ce.ComplexExercises)
            .HasForeignKey(ce => ce.ComplexId);
    }
}
