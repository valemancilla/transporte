using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.documents_vehicles.Infrastructure.entity;

public sealed class DocumentsVehiclesEntityConfiguration : IEntityTypeConfiguration<DocumentsVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsVehiclesEntity> builder)
    {
        builder.ToTable("documents_vehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.TypeDocumentId).HasColumnName("type_document_id").IsRequired();
        builder.Property(x => x.DocumentNumber).HasColumnName("document_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.ExpirationDate).HasColumnName("expiration_date");
        builder.Property(x => x.FileUrl).HasColumnName("file_url").HasColumnType("text");
        builder.Property(x => x.DocumentStatusId).HasColumnName("document_status_id").IsRequired();

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.DocumentsVehicles)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeDocument)
            .WithMany(x => x.DocumentsVehicles)
            .HasForeignKey(x => x.TypeDocumentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DocumentStatus)
            .WithMany(x => x.DocumentsVehicles)
            .HasForeignKey(x => x.DocumentStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
