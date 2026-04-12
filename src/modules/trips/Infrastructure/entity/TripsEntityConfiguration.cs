using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.trips.Infrastructure.entity;

public sealed class TripsEntityConfiguration : IEntityTypeConfiguration<TripsEntity>
{
    public void Configure(EntityTypeBuilder<TripsEntity> builder)
    {
        builder.ToTable("trips");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.OriginCityId).HasColumnName("origin_city_id").IsRequired();
        builder.Property(x => x.DestinationCityId).HasColumnName("destination_city_id").IsRequired();
        builder.Property(x => x.FinalPrice).HasColumnName("final_price").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.StartTime).HasColumnName("start_time");
        builder.Property(x => x.EndTime).HasColumnName("end_time");
        builder.Property(x => x.TripStatusId).HasColumnName("trip_status_id").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.Trips)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Trips)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.Trips)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.OriginCity)
            .WithMany(x => x.TripsAsOrigin)
            .HasForeignKey(x => x.OriginCityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DestinationCity)
            .WithMany(x => x.TripsAsDestination)
            .HasForeignKey(x => x.DestinationCityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TripStatus)
            .WithMany(x => x.Trips)
            .HasForeignKey(x => x.TripStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
