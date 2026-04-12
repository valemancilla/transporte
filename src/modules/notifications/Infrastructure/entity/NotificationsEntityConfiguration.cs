using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace transporte.src.modules.notifications.Infrastructure.entity;

public sealed class NotificationsEntityConfiguration : IEntityTypeConfiguration<NotificationsEntity>
{
    public void Configure(EntityTypeBuilder<NotificationsEntity> builder)
    {
        builder.ToTable("notifications");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.PersonId).HasColumnName("person_id").IsRequired();
        builder.Property(x => x.Title).HasColumnName("title").HasMaxLength(150).IsRequired();
        builder.Property(x => x.Body).HasColumnName("body").HasColumnType("text").IsRequired();
        builder.Property(x => x.NotificationTypeId).HasColumnName("notification_type_id").IsRequired();
        builder.Property(x => x.IsRead).HasColumnName("is_read").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").IsRequired();

        builder.HasOne(x => x.Person)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.PersonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.NotificationType)
            .WithMany(x => x.Notifications)
            .HasForeignKey(x => x.NotificationTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
