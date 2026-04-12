using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.audit_log.Infrastructure.entity;

public sealed class AuditLogEntityConfiguration : IEntityTypeConfiguration<AuditLogEntity>
{
    public void Configure(EntityTypeBuilder<AuditLogEntity> builder)
    {
        builder.ToTable("audit_log");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Action).HasColumnName("action").HasMaxLength(50).IsRequired();
        builder.Property(x => x.TableName).HasColumnName("table_name").HasMaxLength(50).IsRequired();
        builder.Property(x => x.RecordId).HasColumnName("record_id").IsRequired();
        builder.Property(x => x.OldValues).HasColumnName("old_values").HasColumnType("json");
        builder.Property(x => x.NewValues).HasColumnName("new_values").HasColumnType("json");
        builder.Property(x => x.IpAddress).HasColumnName("ip_address").HasMaxLength(45);
        builder.Property(x => x.UserAgent).HasColumnName("user_agent").HasColumnType("text");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.AuditLogs)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}