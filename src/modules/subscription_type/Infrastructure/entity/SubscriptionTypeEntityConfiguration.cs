using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.subscription_type.Infrastructure.entity;

public sealed class SubscriptionTypeEntityConfiguration : IEntityTypeConfiguration<SubscriptionTypeEntity>
{
    public void Configure(EntityTypeBuilder<SubscriptionTypeEntity> builder)
    {
        builder.ToTable("subscription_type");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}