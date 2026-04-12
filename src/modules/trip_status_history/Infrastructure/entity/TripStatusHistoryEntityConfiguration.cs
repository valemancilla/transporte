using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.trip_status_history.Infrastructure.entity;

public sealed class TripStatusHistoryEntityConfiguration : IEntityTypeConfiguration<TripStatusHistoryEntity>
{
    public void Configure(EntityTypeBuilder<TripStatusHistoryEntity> builder)
    {
        builder.ToTable("trip_status_history");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.TripStatusId).HasColumnName("trip_status_id").IsRequired();
        builder.Property(x => x.ChangedAt).HasColumnName("changed_at").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.TripStatusHistories)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TripStatus)
            .WithMany(x => x.TripStatusHistories)
            .HasForeignKey(x => x.TripStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
