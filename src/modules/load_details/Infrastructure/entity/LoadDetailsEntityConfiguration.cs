using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.load_details.Infrastructure.entity;

public sealed class LoadDetailsEntityConfiguration : IEntityTypeConfiguration<LoadDetailsEntity>
{
    public void Configure(EntityTypeBuilder<LoadDetailsEntity> builder)
    {
        builder.ToTable("load_details");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.DetailKey).HasColumnName("detail_key").HasMaxLength(100).IsRequired();
        builder.Property(x => x.DetailValue).HasColumnName("detail_value").HasColumnType("text").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.LoadDetails)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
