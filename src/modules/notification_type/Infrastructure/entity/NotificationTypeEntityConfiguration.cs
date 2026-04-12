using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.notification_type.Infrastructure.entity;

public sealed class NotificationTypeEntityConfiguration : IEntityTypeConfiguration<NotificationTypeEntity>
{
    public void Configure(EntityTypeBuilder<NotificationTypeEntity> builder)
    {
        builder.ToTable("notification_type");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnName("description").HasColumnType("text");
    }
}