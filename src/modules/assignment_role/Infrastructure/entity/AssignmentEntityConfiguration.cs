using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.assignment_role.Infrastructure.entity;

public sealed class AssignmentEntityConfiguration : IEntityTypeConfiguration<AssignmentEntity>
{
    public void Configure(EntityTypeBuilder<AssignmentEntity> builder)
    {
        builder.ToTable("assignment_role");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}