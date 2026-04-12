using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.documents_drivers.Infrastructure.entity;

public sealed class DocumentsDriversEntityConfiguration : IEntityTypeConfiguration<DocumentsDriversEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsDriversEntity> builder)
    {
        builder.ToTable("documents_drivers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("document_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.DocumentsDrivers)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeDocument)
            .WithMany(x => x.DocumentsDrivers)
            .HasForeignKey(x => x.TypeDocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DocumentStatus)
            .WithMany(x => x.DocumentsDrivers)
            .HasForeignKey(x => x.DocumentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
