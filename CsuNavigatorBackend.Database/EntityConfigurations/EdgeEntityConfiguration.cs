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
            .WithMany(mp => mp.EdgesAsPoint1)
            .HasForeignKey(e => e.Point1Id)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.Point2)
            .WithMany(mp => mp.EdgesAsPoint2)
            .HasForeignKey(e => e.Point2Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}