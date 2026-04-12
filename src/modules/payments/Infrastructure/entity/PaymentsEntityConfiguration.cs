using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.payments.Infrastructure.entity;

public sealed class PaymentsEntityConfiguration : IEntityTypeConfiguration<PaymentsEntity>
{
    public void Configure(EntityTypeBuilder<PaymentsEntity> builder)
    {
        builder.ToTable("payments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.WalletId).HasColumnName("wallet_id").IsRequired();
        builder.Property(x => x.PaymentProviderId).HasColumnName("payment_provider_id").IsRequired();
        builder.Property(x => x.PaymentStatusId).HasColumnName("payment_status_id").IsRequired();
        builder.Property(x => x.ExternalReference).HasColumnName("external_reference").HasMaxLength(120).IsRequired();
        builder.Property(x => x.AmountMoney).HasColumnName("amount_money").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Wallet)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.WalletId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentProvider)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.PaymentProviderId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.PaymentStatus)
            .WithMany(x => x.Payments)
            .HasForeignKey(x => x.PaymentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
