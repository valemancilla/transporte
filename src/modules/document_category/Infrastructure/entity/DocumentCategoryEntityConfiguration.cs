using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.document_category.Infrastructure.entity;

public sealed class DocumentCategoryEntityConfiguration : IEntityTypeConfiguration<DocumentCategoryEntity>
{
    public void Configure(EntityTypeBuilder<DocumentCategoryEntity> builder)
    {
        builder.ToTable("document_category");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}
