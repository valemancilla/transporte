using transporte.src.modules.bids.Infrastructure.entity;
using transporte.src.modules.company_vehicles.Infrastructure.entity;
using transporte.src.modules.documents_vehicles.Infrastructure.entity;
using transporte.src.modules.drivers_vehicles.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.trip_assignments.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;
using transporte.src.modules.type_vehicles.Infrastructure.entity;
using transporte.src.modules.vehicles_status.Infrastructure.entity;

namespace transporte.src.modules.vehicles.Infrastructure.entity;

public sealed class VehiclesEntity
{
    public Guid Id { get; set; }

    public string Plate { get; set; } = string.Empty;

    public Guid TypeVehicleId { get; set; }

    public string Brand { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int Year { get; set; }

    public string Color { get; set; } = string.Empty;

    public Guid OwnerPersonId { get; set; }

    public string ChassisNumber { get; set; } = string.Empty;

    public Guid VehicleStatusId { get; set; }

    public PersonsEntity Owner { get; set; } = null!;

    public TypeVehiclesEntity TypeVehicle { get; set; } = null!;

    public VehiclesStatusEntity VehicleStatus { get; set; } = null!;

    public ICollection<TripsEntity> Trips { get; set; } = new List<TripsEntity>();

    public ICollection<BidsEntity> Bids { get; set; } = new List<BidsEntity>();

    public ICollection<DocumentsVehiclesEntity> DocumentsVehicles { get; set; } = new List<DocumentsVehiclesEntity>();

    public ICollection<DriversVehiclesEntity> DriversVehicleLinks { get; set; } = new List<DriversVehiclesEntity>();

    public ICollection<CompanyVehiclesEntity> CompanyVehicleLinks { get; set; } = new List<CompanyVehiclesEntity>();

    public ICollection<TripAssignmentEntity> TripAssignments { get; set; } = new List<TripAssignmentEntity>();
}
