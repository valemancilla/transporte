using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.dispute_status.Infrastructure.entity;

public sealed class DisputeStatusEntityConfiguration : IEntityTypeConfiguration<DisputeStatusEntity>
{
    public void Configure(EntityTypeBuilder<DisputeStatusEntity> builder)
    {
        builder.ToTable("dispute_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}