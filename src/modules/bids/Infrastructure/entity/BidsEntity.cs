using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.loads.Infrastructure.entity;
using transporte.src.modules.status_bids.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.bids.Infrastructure.entity;

public sealed class BidsEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public Guid DriverId { get; set; }

    public Guid VehicleId { get; set; }

    public decimal Amount { get; set; }

    public Guid StatusBidsId { get; set; }

    public DateTime CreatedAt { get; set; }

    public LoadsEntity Load { get; set; } = null!;

    public DriversEntity Driver { get; set; } = null!;

    public VehiclesEntity Vehicle { get; set; } = null!;

    public StatusBidsEntity BidStatus { get; set; } = null!;
}
