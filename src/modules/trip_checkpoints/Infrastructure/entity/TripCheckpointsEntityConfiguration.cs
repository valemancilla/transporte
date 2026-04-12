using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.trip_checkpoints.Infrastructure.entity;

public sealed class TripCheckpointsEntityConfiguration : IEntityTypeConfiguration<TripCheckpointsEntity>
{
    public void Configure(EntityTypeBuilder<TripCheckpointsEntity> builder)
    {
        builder.ToTable("trip_checkpoints");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.Sequence).HasColumnName("sequence").IsRequired();
        builder.Property(x => x.Latitude).HasColumnName("latitude").HasColumnType("decimal(10,7)").IsRequired();
        builder.Property(x => x.Longitude).HasColumnName("longitude").HasColumnType("decimal(10,7)").IsRequired();
        builder.Property(x => x.CheckpointTime).HasColumnName("checkpoint_time").IsRequired();
        builder.Property(x => x.Notes).HasColumnName("notes").HasColumnType("text");

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.TripCheckpoints)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
