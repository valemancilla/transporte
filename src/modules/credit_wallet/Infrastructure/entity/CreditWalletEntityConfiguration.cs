using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.credit_wallet.Infrastructure.entity;

public sealed class CreditWalletEntityConfiguration : IEntityTypeConfiguration<CreditWalletEntity>
{
    public void Configure(EntityTypeBuilder<CreditWalletEntity> builder)
    {
        builder.ToTable("credit_wallet");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Balance).HasColumnName("balance").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.LastUpdate).HasColumnName("last_update").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.CreditWallets)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
