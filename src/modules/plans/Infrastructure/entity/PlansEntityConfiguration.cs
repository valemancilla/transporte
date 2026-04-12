using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.plans.Infrastructure.entity;

public sealed class PlansEntityConfiguration : IEntityTypeConfiguration<PlansEntity>
{
    public void Configure(EntityTypeBuilder<PlansEntity> builder)
    {
        builder.ToTable("plans");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.BillingPeriod).HasColumnName("billing_period").HasMaxLength(50).IsRequired();
    }
}
