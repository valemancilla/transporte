using transporte.src.modules.documents_status.Infrastructure.entity;
using transporte.src.modules.transport_companies.Infrastructure.entity;
using transporte.src.modules.type_documents.Infrastructure.entity;

namespace transporte.src.modules.company_documents.Infrastructure.entity;

public sealed class CompanyDocumentsEntity
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public Guid TypeDocumentId { get; set; }

    public Guid DocumentStatusId { get; set; }

    public string? FileUrl { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public TransportCompaniesEntity Company { get; set; } = null!;

    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}
