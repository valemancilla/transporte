using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.reason_disputes.Infrastructure.entity;

public sealed class ReasonDisputesEntityConfiguration : IEntityTypeConfiguration<ReasonDisputesEntity>
{
    public void Configure(EntityTypeBuilder<ReasonDisputesEntity> builder)
    {
        builder.ToTable("reason_disputes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}