using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.auth_sessions.Infrastructure.entity;

public sealed class AuthSessionsEntityConfiguration : IEntityTypeConfiguration<AuthSessionsEntity>
{
    public void Configure(EntityTypeBuilder<AuthSessionsEntity> builder)
    {
        builder.ToTable("auth_sessions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.SessionToken).HasColumnName("session_token").HasColumnType("text").IsRequired();
        builder.Property(x => x.ExpiresAt).HasColumnName("expires_at").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();
        builder.Property(x => x.IpAddress).HasColumnName("ip_address").HasMaxLength(45);

        builder.HasOne(x => x.Person)
            .WithMany(x => x.AuthSessions)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
