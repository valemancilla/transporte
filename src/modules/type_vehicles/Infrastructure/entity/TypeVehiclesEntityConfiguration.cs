using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.type_vehicles.Infrastructure.entity;

public sealed class TypeVehiclesEntityConfiguration : IEntityTypeConfiguration<TypeVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<TypeVehiclesEntity> builder)
    {
        builder.ToTable("type_vehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}