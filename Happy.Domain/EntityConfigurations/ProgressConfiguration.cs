using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class ProgressConfiguration : IEntityTypeConfiguration<Progress>
{
    public void Configure(EntityTypeBuilder<Progress> builder)
    {
        builder
            .ToTable("Progresses")
            .HasKey(p => p.Id);

        builder
            .Property(p => p.Weight)
            .IsRequired(false);

        builder
            .Property(p => p.NumberOfRepetitions)
            .IsRequired();

        builder
            .Property(p => p.Date)
            .IsRequired();

        builder
            .Property(p => p.RateOfPerceivedExertion)
            .IsRequired(false);

        #region Navigation properties

        builder
            .HasOne(p => p.User)
            .WithMany(p => p.Progresses)
            .HasForeignKey(p => p.UserId)
            .IsRequired();

        builder
            .HasOne(p => p.Exercise)
            .WithMany(p => p.Progresses)
            .HasForeignKey(p => p.ExerciseId)
            .IsRequired();

        #endregion
    }
}
