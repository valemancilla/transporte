using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.transport_companies.Infrastructure.entity;

public sealed class TransportCompaniesEntityConfiguration : IEntityTypeConfiguration<TransportCompaniesEntity>
{
    public void Configure(EntityTypeBuilder<TransportCompaniesEntity> builder)
    {
        builder.ToTable("transport_companies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(150).IsRequired();
        builder.Property(x => x.TaxId).HasColumnName("tax_id").HasMaxLength(50);
        builder.Property(x => x.CityId).HasColumnName("city_id").IsRequired();
        builder.Property(x => x.CompaniesStatusId).HasColumnName("companies_status_id").IsRequired();
        builder.Property(x => x.LegalRepresentativePersonId).HasColumnName("legal_representative_person_id");

        builder.HasOne(x => x.City)
            .WithMany(x => x.TransportCompanies)
            .HasForeignKey(x => x.CityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.CompaniesStatus)
            .WithMany(x => x.TransportCompanies)
            .HasForeignKey(x => x.CompaniesStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LegalRepresentative)
            .WithMany(x => x.CompaniesAsLegalRepresentative)
            .HasForeignKey(x => x.LegalRepresentativePersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
