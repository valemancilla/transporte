using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.status_trip.Infrastructure.entity;

public sealed class StatusTripEntityConfiguration : IEntityTypeConfiguration<StatusTripEntity>
{
    public void Configure(EntityTypeBuilder<StatusTripEntity> builder)
    {
        builder.ToTable("status_trip");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}