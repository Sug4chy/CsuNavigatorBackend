using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class MapEntityConfiguration : IEntityTypeConfiguration<Map>
{
    public void Configure(EntityTypeBuilder<Map> builder)
    {
        builder.ToTable("Map");

        builder.HasKey(m => m.Id);
        builder.HasIndex(m => m.Title).IsUnique();  

        builder.HasOne(m => m.Organization)
            .WithMany(organization => organization.Maps)
            .HasForeignKey(m => m.OrganizationId);
        builder.HasOne(m => m.Image)
            .WithOne(i => i.Map)
            .HasForeignKey<Map>(m => m.ImageId);
        builder.HasMany(m => m.Edges)
            .WithOne(e => e.Map)
            .HasForeignKey(e => e.MapId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.PointsWithoutEdges)
            .WithOne(p => p.MapAsPointWithoutEdge)
            .OnDelete(DeleteBehavior.Cascade);
    }
}