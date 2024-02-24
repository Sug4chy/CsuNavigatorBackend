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

        builder.HasOne(mp => mp.EdgeAsPoint1)
            .WithOne(e => e.Point1)
            .HasForeignKey<Edge>(e => e.Point1Id);
        builder.HasOne(mp => mp.EdgeAsPoint2)
            .WithOne(e => e.Point2)
            .HasForeignKey<Edge>(e => e.Point2Id);

        builder.Property(mp => mp.MarkerType)
             .HasConversion<string>();
    }
}