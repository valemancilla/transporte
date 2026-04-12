using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.drivers_vehicles.Infrastructure.entity;

public sealed class DriversVehiclesEntityConfiguration : IEntityTypeConfiguration<DriversVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<DriversVehiclesEntity> builder)
    {
        builder.ToTable("drivers_vehicles");

        builder.HasKey(x => new { x.DriverId, x.VehicleId });
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.DriversVehicleLinks)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.DriversVehicleLinks)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}