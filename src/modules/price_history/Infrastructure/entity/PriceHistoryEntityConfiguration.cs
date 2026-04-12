using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.price_history.Infrastructure.entity;

public sealed class PriceHistoryEntityConfiguration : IEntityTypeConfiguration<PriceHistoryEntity>
{
    public void Configure(EntityTypeBuilder<PriceHistoryEntity> builder)
    {
        builder.ToTable("price_history");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PlanId).HasColumnName("plan_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.ValidFrom).HasColumnName("valid_from").IsRequired();
        builder.Property(x => x.ValidTo).HasColumnName("valid_to");

        builder.HasOne(x => x.Plan)
            .WithMany(x => x.PriceHistories)
            .HasForeignKey(x => x.PlanId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
