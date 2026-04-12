using transporte.src.modules.states_regions.Infrastructure.entity;

namespace transporte.src.modules.countries.Infrastructure.entity;

public sealed class CountriesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string IsoCode { get; set; } = string.Empty;

    public ICollection<StatesRegionsEntity> StatesRegions { get; set; } = new List<StatesRegionsEntity>();
}
