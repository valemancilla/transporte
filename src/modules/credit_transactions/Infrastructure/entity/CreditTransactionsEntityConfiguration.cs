using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.credit_transactions.Infrastructure.entity;

public sealed class CreditTransactionsEntityConfiguration : IEntityTypeConfiguration<CreditTransactionsEntity>
{
    public void Configure(EntityTypeBuilder<CreditTransactionsEntity> builder)
    {
        builder.ToTable("credit_transactions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CreditWalletId).HasColumnName("credit_wallet_id").IsRequired();
        builder.Property(x => x.TransactionTypeId).HasColumnName("transaction_type_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.CreditWallet)
            .WithMany(x => x.CreditTransactions)
            .HasForeignKey(x => x.CreditWalletId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TransactionType)
            .WithMany(x => x.CreditTransactions)
            .HasForeignKey(x => x.TransactionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
