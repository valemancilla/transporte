using transporte.src.modules.cities_municipalities.Infrastructure.entity;
using transporte.src.modules.companies_status.Infrastructure.entity;
using transporte.src.modules.company_documents.Infrastructure.entity;
using transporte.src.modules.company_drivers.Infrastructure.entity;
using transporte.src.modules.company_vehicles.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.person_transport.Infrastructure.entity;

namespace transporte.src.modules.transport_companies.Infrastructure.entity;

public sealed class TransportCompaniesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? TaxId { get; set; }

    public Guid CityId { get; set; }

    public Guid CompaniesStatusId { get; set; }

    public Guid? LegalRepresentativePersonId { get; set; }

    public CitiesMunicipalitiesEntity City { get; set; } = null!;

    public CompaniesStatusEntity CompaniesStatus { get; set; } = null!;

    public PersonsEntity? LegalRepresentative { get; set; }

    public ICollection<PersonsEntity> Persons { get; set; } = new List<PersonsEntity>();

    public ICollection<PersonTransportEntity> PersonTransportLinks { get; set; } = new List<PersonTransportEntity>();

    public ICollection<CompanyVehiclesEntity> CompanyVehicleLinks { get; set; } = new List<CompanyVehiclesEntity>();

    public ICollection<CompanyDocumentsEntity> CompanyDocuments { get; set; } = new List<CompanyDocumentsEntity>();

    public ICollection<CompanyDriversEntity> CompanyDriverLinks { get; set; } = new List<CompanyDriversEntity>();
}
