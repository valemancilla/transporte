using transporte.src.modules.status_trip.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.trip_status_history.Infrastructure.entity;

public sealed class TripStatusHistoryEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid TripStatusId { get; set; }

    public DateTime ChangedAt { get; set; }

    public TripsEntity Trip { get; set; } = null!;

    public StatusTripEntity TripStatus { get; set; } = null!;
}
