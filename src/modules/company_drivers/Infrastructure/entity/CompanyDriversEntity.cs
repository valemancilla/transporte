using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.transport_companies.Infrastructure.entity;

namespace transporte.src.modules.company_drivers.Infrastructure.entity;

public sealed class CompanyDriversEntity
{
    public Guid CompanyId { get; set; }

    public Guid DriverId { get; set; }

    public TransportCompaniesEntity Company { get; set; } = null!;

    public DriversEntity Driver { get; set; } = null!;
}
