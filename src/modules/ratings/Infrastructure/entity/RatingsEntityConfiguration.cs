using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.ratings.Infrastructure.entity;

public sealed class RatingsEntityConfiguration : IEntityTypeConfiguration<RatingsEntity>
{
    public void Configure(EntityTypeBuilder<RatingsEntity> builder)
    {
        builder.ToTable("ratings");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.TripId).HasColumnName("trip_id").IsRequired();
        builder.Property(x => x.RaterPersonId).HasColumnName("rater_person_id").IsRequired();
        builder.Property(x => x.RatedPersonId).HasColumnName("rated_person_id").IsRequired();
        builder.Property(x => x.Score).HasColumnName("score").IsRequired();
        builder.Property(x => x.Comment).HasColumnName("comment").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Trip)
            .WithMany(x => x.Ratings)
            .HasForeignKey(x => x.TripId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RaterPerson)
            .WithMany(x => x.RatingsGiven)
            .HasForeignKey(x => x.RaterPersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.RatedPerson)
            .WithMany(x => x.RatingsReceived)
            .HasForeignKey(x => x.RatedPersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
