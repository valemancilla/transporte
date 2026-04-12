using transporte.src.modules.bids.Infrastructure.entity;
using transporte.src.modules.company_drivers.Infrastructure.entity;
using transporte.src.modules.documents_drivers.Infrastructure.entity;
using transporte.src.modules.drivers_vehicles.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.trip_assignments.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.drivers.Infrastructure.entity;

public sealed class DriversEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string LicenseNumber { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public ICollection<BidsEntity> Bids { get; set; } = new List<BidsEntity>();

    public ICollection<TripsEntity> Trips { get; set; } = new List<TripsEntity>();

    public ICollection<DocumentsDriversEntity> DocumentsDrivers { get; set; } = new List<DocumentsDriversEntity>();

    public ICollection<DriversVehiclesEntity> DriversVehicleLinks { get; set; } = new List<DriversVehiclesEntity>();

    public ICollection<TripAssignmentEntity> TripAssignments { get; set; } = new List<TripAssignmentEntity>();

    public ICollection<CompanyDriversEntity> CompanyDriverLinks { get; set; } = new List<CompanyDriversEntity>();
}
