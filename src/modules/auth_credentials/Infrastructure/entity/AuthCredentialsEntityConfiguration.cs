using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.auth_credentials.Infrastructure.entity;

public sealed class AuthCredentialsEntityConfiguration : IEntityTypeConfiguration<AuthCredentialsEntity>
{
    public void Configure(EntityTypeBuilder<AuthCredentialsEntity> builder)
    {
        builder.ToTable("auth_credentials");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(120).IsRequired();
        builder.Property(x => x.PasswordHash).HasColumnName("password_hash").HasColumnType("text").IsRequired();
        builder.Property(x => x.LastLogin).HasColumnName("last_login");
        builder.Property(x => x.FailedAttempts).HasColumnName("failed_attempts").IsRequired();
        builder.Property(x => x.IsActive).HasColumnName("is_active").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.AuthCredentials)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
