using transporte.src.modules.transport_companies.Infrastructure.entity;

namespace transporte.src.modules.companies_status.Infrastructure.entity;

public sealed class CompaniesStatusEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<TransportCompaniesEntity> TransportCompanies { get; set; } = new List<TransportCompaniesEntity>();
}
