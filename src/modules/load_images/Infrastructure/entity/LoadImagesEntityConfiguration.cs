using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.load_images.Infrastructure.entity;

public sealed class LoadImagesEntityConfiguration : IEntityTypeConfiguration<LoadImagesEntity>
{
    public void Configure(EntityTypeBuilder<LoadImagesEntity> builder)
    {
        builder.ToTable("load_images");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.Url).HasColumnName("url").HasColumnType("text").IsRequired();
        builder.Property(x => x.SortOrder).HasColumnName("sort_order").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.LoadImages)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
