using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.person_status.Infrastructure.entity;

public sealed class PersonStatusEntityConfiguration : IEntityTypeConfiguration<PersonStatusEntity>
{
    public void Configure(EntityTypeBuilder<PersonStatusEntity> builder)
    {
        builder.ToTable("person_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}