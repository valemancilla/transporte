using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.payment_providers.Infrastructure.entity;

public sealed class PaymentProvidersEntityConfiguration : IEntityTypeConfiguration<PaymentProvidersEntity>
{
    public void Configure(EntityTypeBuilder<PaymentProvidersEntity> builder)
    {
        builder.ToTable("payment_providers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}