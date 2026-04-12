using transporte.src.modules.city_pricing_rules.Infrastructure.entity;
using transporte.src.modules.loads.Infrastructure.entity;
using transporte.src.modules.states_regions.Infrastructure.entity;
using transporte.src.modules.transport_companies.Infrastructure.entity;
using transporte.src.modules.travel_scale.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.cities_municipalities.Infrastructure.entity;

public sealed class CitiesMunicipalitiesEntity
{
    public Guid Id { get; set; }

    public Guid StateRegionId { get; set; }

    public string Name { get; set; } = string.Empty;

    public StatesRegionsEntity StateRegion { get; set; } = null!;

    public ICollection<TransportCompaniesEntity> TransportCompanies { get; set; } = new List<TransportCompaniesEntity>();

    public ICollection<LoadsEntity> LoadsAsOrigin { get; set; } = new List<LoadsEntity>();

    public ICollection<LoadsEntity> LoadsAsDestination { get; set; } = new List<LoadsEntity>();

    public ICollection<TripsEntity> TripsAsOrigin { get; set; } = new List<TripsEntity>();

    public ICollection<TripsEntity> TripsAsDestination { get; set; } = new List<TripsEntity>();

    public ICollection<CityPricingRulesEntity> CityPricingRules { get; set; } = new List<CityPricingRulesEntity>();

    public ICollection<TravelScaleEntity> TravelScales { get; set; } = new List<TravelScaleEntity>();
}
