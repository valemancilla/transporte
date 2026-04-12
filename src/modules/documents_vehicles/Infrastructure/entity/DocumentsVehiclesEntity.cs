using transporte.src.modules.documents_status.Infrastructure.entity;
using transporte.src.modules.type_documents.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.documents_vehicles.Infrastructure.entity;

public sealed class DocumentsVehiclesEntity
{
    public Guid Id { get; set; }

    public Guid VehicleId { get; set; }

    public Guid TypeDocumentId { get; set; }

    public string DocumentNumber { get; set; } = string.Empty;

    public DateOnly? ExpirationDate { get; set; }

    public string? FileUrl { get; set; }

    public Guid DocumentStatusId { get; set; }

    public VehiclesEntity Vehicle { get; set; } = null!;

    public TypeDocumentsEntity TypeDocument { get; set; } = null!;

    public DocumentsStatusEntity DocumentStatus { get; set; } = null!;
}
