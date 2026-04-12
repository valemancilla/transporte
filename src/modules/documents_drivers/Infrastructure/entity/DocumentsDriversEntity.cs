using transporte.src.modules.documents_status.Infrastructure.entity;
using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.type_documents.Infrastructure.entity;

namespace transporte.src.modules.documents_drivers.Infrastructure.entity;

public sealed class DocumentsDriversEntity
{
    public Guid Id { get; set; }

    public Guid DriverId { get; set; }

    public Guid TypeDocumentId { get; set; }

    public string DocumentNumber { get; set; } = string.Empty;

    public DateOnly? ExpirationDate { get; set; }

    public string? FileUrl { get; set; }

    public Guid DocumentStatusId { get; set; }

    public DriversEntity Driver { get; set; } = null!;

    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}
