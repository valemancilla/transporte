using transporte.src.modules.cities_municipalities.Infrastructure.entity;

namespace transporte.src.modules.city_pricing_rules.Infrastructure.entity;

public sealed class CityPricingRulesEntity
{
    public Guid Id { get; set; }

    public Guid CityId { get; set; }

    public decimal BasePrice { get; set; }

    public string? RuleJson { get; set; }

    public CitiesMunicipalitiesEntity City { get; set; } = null!;
}
