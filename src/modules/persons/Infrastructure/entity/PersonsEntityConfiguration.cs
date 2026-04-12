using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.persons.Infrastructure.entity;

public sealed class PersonsEntityConfiguration : IEntityTypeConfiguration<PersonsEntity>
{
    public void Configure(EntityTypeBuilder<PersonsEntity> builder)
    {
        builder.ToTable("persons");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.FirstName).HasColumnName("first_name").HasMaxLength(80).IsRequired();
        builder.Property(x => x.LastName).HasColumnName("last_name").HasMaxLength(80).IsRequired();
        builder.Property(x => x.IdNum).HasColumnName("id_num").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Phone).HasColumnName("phone").HasMaxLength(20).IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(120).IsRequired();
        builder.Property(x => x.PersonStatusId).HasColumnName("person_status_id").IsRequired();
        builder.Property(x => x.CompanyId).HasColumnName("company_id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.PersonStatus)
            .WithMany(x => x.Persons)
            .HasForeignKey(x => x.PersonStatusId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Company)
            .WithMany(x => x.Persons)
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
