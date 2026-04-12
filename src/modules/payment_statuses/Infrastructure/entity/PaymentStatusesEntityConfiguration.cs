using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.payment_statuses.Infrastructure.entity;

public sealed class PaymentStatusesEntityConfiguration : IEntityTypeConfiguration<PaymentStatusesEntity>
{
    public void Configure(EntityTypeBuilder<PaymentStatusesEntity> builder)
    {
        builder.ToTable("payment_statuses");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}