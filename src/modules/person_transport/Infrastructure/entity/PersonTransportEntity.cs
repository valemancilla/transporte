using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.transport_companies.Infrastructure.entity;

namespace transporte.src.modules.person_transport.Infrastructure.entity;

public sealed class PersonTransportEntity
{
    public Guid PersonId { get; set; }

    public Guid TransportCompanyId { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public TransportCompaniesEntity TransportCompany { get; set; } = null!;
}
