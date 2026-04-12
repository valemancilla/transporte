using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.person_transport.Infrastructure.entity;

public sealed class PersonTransportEntityConfiguration : IEntityTypeConfiguration<PersonTransportEntity>
{
    public void Configure(EntityTypeBuilder<PersonTransportEntity> builder)
    {
        builder.ToTable("person_transport");

        builder.HasKey(x => new { x.PersonId, x.TransportCompanyId });
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.TransportCompanyId).HasColumnName("transport_company_id").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.PersonTransportLinks)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.TransportCompany)
            .WithMany(x => x.PersonTransportLinks)
            .HasForeignKey(x => x.TransportCompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}