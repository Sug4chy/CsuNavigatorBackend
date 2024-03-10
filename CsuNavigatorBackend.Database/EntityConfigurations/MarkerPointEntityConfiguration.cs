using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class MarkerPointEntityConfiguration : IEntityTypeConfiguration<MarkerPoint>
{
    public void Configure(EntityTypeBuilder<MarkerPoint> builder)
    {
        builder.ToTable("MarkerPoint");

        builder.HasKey(mp => mp.Id);

        builder.HasMany(mp => mp.EdgesAsPoint1)
            .WithOne(e => e.Point1)
            .HasForeignKey(e => e.Point1Id);
        builder.HasMany(mp => mp.EdgesAsPoint2)
            .WithOne(e => e.Point2)
            .HasForeignKey(e => e.Point2Id);

        builder.Property(mp => mp.MarkerType)
             .HasConversion<string>();
    }
}