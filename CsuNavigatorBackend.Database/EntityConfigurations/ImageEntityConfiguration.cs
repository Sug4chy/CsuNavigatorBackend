using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CsuNavigatorBackend.Database.EntityConfigurations;

public class ImageEntityConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        // builder.ToTable("Image");
        //
        // builder.HasKey(i => i.Id);
        // builder.HasIndex(i => i.FileName).IsUnique();
        //
        // builder.HasOne(i => i.Profile)
        //     .WithOne(p => p.Avatar)
        //     .HasForeignKey<Profile>(p => p.AvatarId);
        // builder.HasOne(i => i.Map)
        //     .WithOne(m => m.Image)
        //     .HasForeignKey<Map>(m => m.ImageId);
    }
}