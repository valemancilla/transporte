using transporte.src.modules.cities_municipalities.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.travel_scale.Infrastructure.entity;

public sealed class TravelScaleEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid? CityId { get; set; }

    public decimal WeightKg { get; set; }

    public string? LocationNote { get; set; }

    public DateTime RecordedAt { get; set; }

    public TripsEntity Trip { get; set; } = null!;

    public CitiesMunicipalitiesEntity? City { get; set; }
}
