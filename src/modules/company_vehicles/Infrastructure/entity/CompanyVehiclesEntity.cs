using transporte.src.modules.transport_companies.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.company_vehicles.Infrastructure.entity;

public sealed class CompanyVehiclesEntity
{
    public Guid CompanyId { get; set; }

    public Guid VehicleId { get; set; }

    public TransportCompaniesEntity Company { get; set; } = null!;

    public VehiclesEntity Vehicle { get; set; } = null!;
}
