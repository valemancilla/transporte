using transporte.src.modules.chat_rooms.Infrastructure.entity;
using transporte.src.modules.cities_municipalities.Infrastructure.entity;
using transporte.src.modules.disputes.Infrastructure.entity;
using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.loads.Infrastructure.entity;
using transporte.src.modules.ratings.Infrastructure.entity;
using transporte.src.modules.status_trip.Infrastructure.entity;
using transporte.src.modules.travel_scale.Infrastructure.entity;
using transporte.src.modules.trip_assignments.Infrastructure.entity;
using transporte.src.modules.trip_checkpoints.Infrastructure.entity;
using transporte.src.modules.trip_status_history.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.trips.Infrastructure.entity;

public sealed class TripsEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public Guid VehicleId { get; set; }

    public Guid DriverId { get; set; }

    public Guid OriginCityId { get; set; }

    public Guid DestinationCityId { get; set; }

    public decimal FinalPrice { get; set; }

    public DateTime? StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    public Guid TripStatusId { get; set; }

    public LoadsEntity Load { get; set; } = null!;

    public VehiclesEntity Vehicle { get; set; } = null!;

    public DriversEntity Driver { get; set; } = null!;

    public CitiesMunicipalitiesEntity OriginCity { get; set; } = null!;

    public CitiesMunicipalitiesEntity DestinationCity { get; set; } = null!;

    public StatusTripEntity TripStatus { get; set; } = null!;

    public ICollection<TripAssignmentEntity> TripAssignments { get; set; } = new List<TripAssignmentEntity>();

    public ICollection<ChatRoomsEntity> ChatRooms { get; set; } = new List<ChatRoomsEntity>();

    public ICollection<DisputesEntity> Disputes { get; set; } = new List<DisputesEntity>();

    public ICollection<RatingsEntity> Ratings { get; set; } = new List<RatingsEntity>();

    public ICollection<TripCheckpointsEntity> TripCheckpoints { get; set; } = new List<TripCheckpointsEntity>();

    public ICollection<TripStatusHistoryEntity> TripStatusHistories { get; set; } = new List<TripStatusHistoryEntity>();

    public ICollection<TravelScaleEntity> TravelScales { get; set; } = new List<TravelScaleEntity>();
}
