using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.transaction_types.Infrastructure.entity;

public sealed class TransactionTypesEntityConfiguration : IEntityTypeConfiguration<TransactionTypesEntity>
{
    public void Configure(EntityTypeBuilder<TransactionTypesEntity> builder)
    {
        builder.ToTable("transaction_types");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}