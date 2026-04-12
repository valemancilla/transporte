using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.disputes.Infrastructure.entity;

public sealed class DisputesEntityConfiguration : IEntityTypeConfiguration<DisputesEntity>
{
    public void Configure(EntityTypeBuilder<DisputesEntity> builder)
    {
        builder.ToTable("disputes");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.ReporterPersonId).HasColumnName("reporter_person_id").IsRequired();
        builder.Property(x => x.DisputeStatusId).HasColumnName("dispute_status_id").IsRequired();
        builder.Property(x => x.ReasonDisputesId).HasColumnName("reason_disputes_id").IsRequired();
        builder.Property(x => x.Notes).HasColumnName("notes").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.Disputes)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Reporter)
            .WithMany(x => x.DisputesReported)
            .HasForeignKey(x => x.ReporterPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.DisputeStatus)
            .WithMany(x => x.Disputes)
            .HasForeignKey(x => x.DisputeStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.ReasonDispute)
            .WithMany(x => x.Disputes)
            .HasForeignKey(x => x.ReasonDisputesId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
