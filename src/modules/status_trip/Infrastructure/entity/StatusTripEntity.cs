using transporte.src.modules.trip_status_history.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.status_trip.Infrastructure.entity;

public sealed class StatusTripEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<TripsEntity> Trips { get; set; } = new List<TripsEntity>();

    public ICollection<TripStatusHistoryEntity> TripStatusHistories { get; set; } = new List<TripStatusHistoryEntity>();
}
