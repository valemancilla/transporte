using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.type_load.Infrastructure.entity;

public sealed class TypeLoadEntityConfiguration : IEntityTypeConfiguration<TypeLoadEntity>
{
    public void Configure(EntityTypeBuilder<TypeLoadEntity> builder)
    {
        builder.ToTable("type_load");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}