using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.travel_scale.Infrastructure.entity;

public sealed class TravelScaleEntityConfiguration : IEntityTypeConfiguration<TravelScaleEntity>
{
    public void Configure(EntityTypeBuilder<TravelScaleEntity> builder)
    {
        builder.ToTable("travel_scale");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.CityId).HasColumnName("city_id");
        builder.Property(x => x.WeightKg).HasColumnName("weight_kg").HasColumnType("decimal(12,2)").IsRequired();
        builder.Property(x => x.LocationNote).HasColumnName("location_note").HasColumnType("text");
        builder.Property(x => x.RecordedAt).HasColumnName("recorded_at").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.TravelScales)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.City)
            .WithMany(x => x.TravelScales)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
