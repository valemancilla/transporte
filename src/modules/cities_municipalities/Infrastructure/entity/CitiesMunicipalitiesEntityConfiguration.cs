using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.cities_municipalities.Infrastructure.entity;

public sealed class CitiesMunicipalitiesEntityConfiguration : IEntityTypeConfiguration<CitiesMunicipalitiesEntity>
{
    public void Configure(EntityTypeBuilder<CitiesMunicipalitiesEntity> builder)
    {
        builder.ToTable("cities_municipalities");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.StateRegionId).HasColumnName("state_region_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(120).IsRequired();

        builder.HasOne(x => x.StateRegion)
            .WithMany(x => x.CitiesMunicipalities)
            .HasForeignKey(x => x.StateRegionId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}