using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.states_regions.Infrastructure.entity;

public sealed class StatesRegionsEntityConfiguration : IEntityTypeConfiguration<StatesRegionsEntity>
{
    public void Configure(EntityTypeBuilder<StatesRegionsEntity> builder)
    {
        builder.ToTable("states_regions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.CountryId).HasColumnName("country_id").IsRequired();
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();

        builder.HasOne(x => x.Country)
            .WithMany(x => x.StatesRegions)
            .HasForeignKey(x => x.CountryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}