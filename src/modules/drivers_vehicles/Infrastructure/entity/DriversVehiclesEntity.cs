using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.drivers_vehicles.Infrastructure.entity;

public sealed class DriversVehiclesEntity
{
    public Guid DriverId { get; set; }

    public Guid VehicleId { get; set; }

    public DriversEntity Driver { get; set; } = null!;

    public VehiclesEntity Vehicle { get; set; } = null!;
}
