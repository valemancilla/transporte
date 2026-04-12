using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.countries.Infrastructure.entity;

public sealed class CountriesEntityConfiguration : IEntityTypeConfiguration<CountriesEntity>
{
    public void Configure(EntityTypeBuilder<CountriesEntity> builder)
    {
        builder.ToTable("countries");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.IsoCode).HasColumnName("iso_code").HasMaxLength(3).IsRequired();
    }
}
