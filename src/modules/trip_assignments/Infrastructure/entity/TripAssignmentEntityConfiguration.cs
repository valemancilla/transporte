using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.trip_assignments.Infrastructure.entity;

public sealed class TripAssignmentEntityConfiguration : IEntityTypeConfiguration<TripAssignmentEntity>
{
    public void Configure(EntityTypeBuilder<TripAssignmentEntity> builder)
    {
        builder.ToTable("trip_assignments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.AssignmentRoleId).HasColumnName("assignment_role_id").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.TripAssignments)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.TripAssignments)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.TripAssignments)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.AssignmentRole)
            .WithMany(x => x.TripAssignments)
            .HasForeignKey(x => x.AssignmentRoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
