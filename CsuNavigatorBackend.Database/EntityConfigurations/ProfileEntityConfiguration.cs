using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class ProfileEntityConfiguration : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> builder)
    {
        builder.ToTable("Profile");

        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.User)
            .WithOne(u => u.Profile)
            .HasForeignKey<User>(u => u.ProfileId);
        builder.HasMany(p => p.AllowedOrganizations)
            .WithMany(o => o.WorkersProfiles)
            .UsingEntity(e => e.ToTable("OrganizationWorkers"));
        builder.HasOne(p => p.Avatar)
            .WithOne(i => i.Profile)
            .HasForeignKey<Profile>(p => p.AvatarId);
    }
}