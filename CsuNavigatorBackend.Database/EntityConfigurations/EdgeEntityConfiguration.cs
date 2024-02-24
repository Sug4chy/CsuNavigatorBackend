using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class EdgeEntityConfiguration : IEntityTypeConfiguration<Edge>
{
    public void Configure(EntityTypeBuilder<Edge> builder)
    {
        builder.ToTable("Edge");

        builder.HasKey(e => e.Id);

        builder.HasOne(e => e.Map)
            .WithMany(m => m.Edges)
            .HasForeignKey(e => e.MapId);

        builder.HasOne(e => e.Point1)
            .WithOne(mp => mp.EdgeAsPoint1)
            .HasForeignKey<Edge>(e => e.Point1Id);

        builder.HasOne(e => e.Point2)
            .WithOne(mp => mp.EdgeAsPoint2)
            .HasForeignKey<Edge>(e => e.Point2Id);
    }
}