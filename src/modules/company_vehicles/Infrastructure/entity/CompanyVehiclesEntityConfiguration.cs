using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.company_vehicles.Infrastructure.entity;

public sealed class CompanyVehiclesEntityConfiguration : IEntityTypeConfiguration<CompanyVehiclesEntity>
{
    public void Configure(EntityTypeBuilder<CompanyVehiclesEntity> builder)
    {
        builder.ToTable("company_vehicles");

        builder.HasKey(x => new { x.CompanyId, x.VehicleId });
        builder.Property(x => x.CompanyId).HasColumnName("company_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();

        builder.HasOne(x => x.Company)
            .WithMany(x => x.CompanyVehicleLinks)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.CompanyVehicleLinks)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}