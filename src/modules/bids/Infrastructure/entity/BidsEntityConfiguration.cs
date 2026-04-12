using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.bids.Infrastructure.entity;

public sealed class BidsEntityConfiguration : IEntityTypeConfiguration<BidsEntity>
{
    public void Configure(EntityTypeBuilder<BidsEntity> builder)
    {
        builder.ToTable("bids");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.LoadId).HasColumnName("load_id").IsRequired();
        builder.Property(x => x.DriverId).HasColumnName("driver_id").IsRequired();
        builder.Property(x => x.VehicleId).HasColumnName("vehicle_id").IsRequired();
        builder.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(x => x.StatusBidsId).HasColumnName("status_bids_id").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Load)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.LoadId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Driver)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Vehicle)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.VehicleId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.BidStatus)
            .WithMany(x => x.Bids)
            .HasForeignKey(x => x.StatusBidsId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
