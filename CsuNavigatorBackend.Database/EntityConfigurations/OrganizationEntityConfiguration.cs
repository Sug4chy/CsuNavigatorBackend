using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
{
    public void Configure(EntityTypeBuilder<Organization> builder)
    {
        builder.ToTable("Organization");

        builder.HasKey(o => o.Id);
        builder.HasIndex(o => o.Name);

        builder.HasMany(o => o.Maps)
            .WithOne(m => m.Organization)
            .HasForeignKey(m => m.OrganizationId);
        builder.HasMany(o => o.WorkersProfiles)
            .WithMany(p => p.AllowedOrganizations)
            .UsingEntity(e => e.ToTable("OrganizationWorkers"));
    }
}