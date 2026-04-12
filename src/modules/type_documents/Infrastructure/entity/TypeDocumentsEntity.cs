using transporte.src.modules.company_documents.Infrastructure.entity;
using transporte.src.modules.document_category.Infrastructure.entity;
using transporte.src.modules.documents_customers.Infrastructure.entity;
using transporte.src.modules.documents_drivers.Infrastructure.entity;
using transporte.src.modules.documents_vehicles.Infrastructure.entity;

namespace transporte.src.modules.type_documents.Infrastructure.entity;

public sealed class TypeDocumentsEntity
{
    public Guid Id { get; set; }

    public Guid? DocumentCategoryId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public DocumentCategoryEntity? DocumentCategory { get; set; }

    public ICollection<DocumentsDriversEntity> DocumentsDrivers { get; set; } = new List<DocumentsDriversEntity>();

    public ICollection<DocumentsCustomersEntity> DocumentsCustomers { get; set; } = new List<DocumentsCustomersEntity>();

    public ICollection<DocumentsVehiclesEntity> DocumentsVehicles { get; set; } = new List<DocumentsVehiclesEntity>();

    public ICollection<CompanyDocumentsEntity> CompanyDocuments { get; set; } = new List<CompanyDocumentsEntity>();
}
