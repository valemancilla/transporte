using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.subscription_status.Infrastructure.entity;

public sealed class SubscriptionStatusEntityConfiguration : IEntityTypeConfiguration<SubscriptionStatusEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionStatusEntity> builder)
    {
        builder.ToTable("subscription_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}