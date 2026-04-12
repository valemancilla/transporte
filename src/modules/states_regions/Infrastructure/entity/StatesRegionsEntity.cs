using transporte.src.modules.cities_municipalities.Infrastructure.entity;
using transporte.src.modules.countries.Infrastructure.entity;

namespace transporte.src.modules.states_regions.Infrastructure.entity;

public sealed class StatesRegionsEntity
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public CountriesEntity Country { get; set; } = null!;

    public ICollection<CitiesMunicipalitiesEntity> CitiesMunicipalities { get; set; } = new List<CitiesMunicipalitiesEntity>();
}
