using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.city_pricing_rules.Infrastructure.entity;

public sealed class CityPricingRulesEntityConfiguration : IEntityTypeConfiguration<CityPricingRulesEntity>
{
    public void Configure(EntityTypeBuilder<CityPricingRulesEntity> builder)
    {
        builder.ToTable("city_pricing_rules");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CityId).HasColumnName("city_id").IsRequired();
        builder.Property(x => x.BasePrice).HasColumnName("base_price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.RuleJson).HasColumnName("rule_json").HasColumnType("json");

        builder.HasOne(x => x.City)
            .WithMany(x => x.CityPricingRules)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
