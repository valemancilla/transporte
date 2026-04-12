using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.vehicles_status.Infrastructure.entity;

public sealed class VehiclesStatusEntityConfiguration : IEntityTypeConfiguration<VehiclesStatusEntity>
{
    public void Configure(EntityTypeBuilder<VehiclesStatusEntity> builder)
    {
        builder.ToTable("vehicles_status");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}