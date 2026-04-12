using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.person_roles.Infrastructure.entity;

public sealed class PersonRolesEntityConfiguration : IEntityTypeConfiguration<PersonRolesEntity>
{
    public void Configure(EntityTypeBuilder<PersonRolesEntity> builder)
    {
        builder.ToTable("person_roles");

        builder.HasKey(x => new { x.PersonId, x.RoleId });
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.RoleId).HasColumnName("role_id").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.PersonRoles)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Role)
            .WithMany(x => x.PersonRoles)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}