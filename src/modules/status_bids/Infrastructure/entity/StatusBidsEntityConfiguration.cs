using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.status_bids.Infrastructure.entity;

public sealed class StatusBidsEntityConfiguration : IEntityTypeConfiguration<StatusBidsEntity>
{
    public void Configure(EntityTypeBuilder<StatusBidsEntity> builder)
    {
        builder.ToTable("status_bids");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}