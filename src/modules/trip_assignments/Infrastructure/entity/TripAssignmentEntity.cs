using transporte.src.modules.assignment_role.Infrastructure.entity;
using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.trip_assignments.Infrastructure.entity;

public sealed class TripAssignmentEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid DriverId { get; set; }

    public Guid VehicleId { get; set; }

    public Guid AssignmentRoleId { get; set; }

    public TripsEntity Trip { get; set; } = null!;

    public DriversEntity Driver { get; set; } = null!;

    public VehiclesEntity Vehicle { get; set; } = null!;

    public AssignmentEntity AssignmentRole { get; set; } = null!;
}
