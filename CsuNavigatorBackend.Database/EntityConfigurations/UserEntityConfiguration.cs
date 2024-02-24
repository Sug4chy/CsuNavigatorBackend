using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // builder.ToTable("User");
        //
        // builder.HasKey(u => u.Id);
        // builder.HasIndex(u => u.Username);
        //
        // builder.HasOne(u => u.Profile)
        //     .WithOne(p => p.User)
        //     .HasForeignKey<User>(u => u.ProfileId);
    }
}