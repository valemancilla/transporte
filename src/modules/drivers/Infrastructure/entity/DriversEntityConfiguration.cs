using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.drivers.Infrastructure.entity;

public sealed class DriversEntityConfiguration : IEntityTypeConfiguration<DriversEntity>
{
    public void Configure(EntityTypeBuilder<DriversEntity> builder)
    {
        builder.ToTable("drivers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.LicenseNumber).HasColumnName("license_number").HasMaxLength(50).IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.Drivers)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
