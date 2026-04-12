using transporte.src.modules.documents_status.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.type_documents.Infrastructure.entity;

namespace transporte.src.modules.documents_customers.Infrastructure.entity;

public sealed class DocumentsCustomersEntity
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid TypeDocumentId { get; set; }

    public string DocumentNumber { get; set; } = string.Empty;

    public DateOnly? ExpirationDate { get; set; }

    public string? FileUrl { get; set; }

    public Guid DocumentStatusId { get; set; }

    public PersonsEntity Customer { get; set; } = null!;

    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}
