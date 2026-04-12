using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.trip_checkpoints.Infrastructure.entity;

public sealed class TripCheckpointsEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public int Sequence { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public DateTime CheckpointTime { get; set; }

    public string? Notes { get; set; }

    public TripsEntity Trip { get; set; } = null!;
}
