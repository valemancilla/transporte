using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.documents_status.Infrastructure.entity;

public sealed class DocumentsStatusEntityConfiguration : IEntityTypeConfiguration<DocumentsStatusEntity>
{
    public void Configure(EntityTypeBuilder<DocumentsStatusEntity> builder)
    {
        builder.ToTable("documents_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}