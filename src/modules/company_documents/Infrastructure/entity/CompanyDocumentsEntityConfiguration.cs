using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.company_documents.Infrastructure.entity;

public sealed class CompanyDocumentsEntityConfiguration : IEntityTypeConfiguration<CompanyDocumentsEntity>
{
    public void Configure(EntityTypeBuilder<CompanyDocumentsEntity> builder)
    {
        builder.ToTable("company_documents");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");

        builder.HasOne(x => x.Company)
            .WithMany(x => x.CompanyDocuments)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeDocument)
            .WithMany(x => x.CompanyDocuments)
            .HasForeignKey(x => x.TypeDocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DocumentStatus)
            .WithMany(x => x.CompanyDocuments)
            .HasForeignKey(x => x.DocumentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
