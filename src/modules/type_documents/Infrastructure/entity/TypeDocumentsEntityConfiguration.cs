using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.type_documents.Infrastructure.entity;

public sealed class TypeDocumentsEntityConfiguration : IEntityTypeConfiguration<TypeDocumentsEntity>
{
    public void Configure(EntityTypeBuilder<TypeDocumentsEntity> builder)
    {
        builder.ToTable("type_documents");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.DocumentCategoryId).HasColumnName("document_category_id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");

        builder.HasOne(x => x.DocumentCategory)
            .WithMany(x => x.TypeDocuments)
            .HasForeignKey(x => x.DocumentCategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
