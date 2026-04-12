using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.vehicles.Infrastructure.entity;

public sealed class VehiclesEntityConfiguration : IEntityTypeConfiguration<VehiclesEntity>
{
    public void Configure(EntityTypeBuilder<VehiclesEntity> builder)
    {
        builder.ToTable("vehicles");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Plate).HasColumnName("plate").HasMaxLength(10).IsRequired();
        builder.Property(x => x.TypeVehicleId).HasColumnName("type_vehicle_id").IsRequired();
        builder.Property(x => x.Brand).HasColumnName("brand").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Model).HasColumnName("model").HasMaxLength(50).IsRequired();
        builder.Property(x => x.Year).HasColumnName("year").IsRequired();
        builder.Property(x => x.Color).HasColumnName("color").HasMaxLength(30).IsRequired();
        builder.Property(x => x.OwnerPersonId).HasColumnName("owner_id").IsRequired();
        builder.Property(x => x.ChassisNumber).HasColumnName("chassis_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.VehicleStatusId).HasColumnName("vehicle_status_id").IsRequired();

        builder.HasOne(x => x.Owner)
            .WithMany(x => x.OwnedVehicles)
            .HasForeignKey(x => x.OwnerPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TypeVehicle)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.TypeVehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.VehicleStatus)
            .WithMany(x => x.Vehicles)
            .HasForeignKey(x => x.VehicleStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
