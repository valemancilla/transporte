using transporte.src.modules.type_documents.Infrastructure.entity;

namespace transporte.src.modules.document_category.Infrastructure.entity;

public sealed class DocumentCategoryEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<TypeDocumentsEntity> TypeDocuments { get; set; } = new List<TypeDocumentsEntity>();
}
