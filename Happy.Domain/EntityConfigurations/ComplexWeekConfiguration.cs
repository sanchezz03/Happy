using Happy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Happy.Domain.EntityConfigurations;

public class ComplexWeekConfiguration : IEntityTypeConfiguration<ComplexWeek>
{
    public void Configure(EntityTypeBuilder<ComplexWeek> builder)
    {
        builder
            .ToTable("ComplexWeeks")
            .HasKey(cw => cw.Id);

        builder
            .HasOne(cw => cw.Week)
            .WithMany(cw => cw.ComplexWeeks)
            .HasForeignKey(cw => cw.WeekId);

        builder
            .HasOne(cw => cw.Complex)
            .WithMany(cw => cw.ComplexWeeks)
            .HasForeignKey(cw => cw.ComplexId);
    }
}
