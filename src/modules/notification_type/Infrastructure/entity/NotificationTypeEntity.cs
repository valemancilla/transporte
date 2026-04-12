using transporte.src.modules.notifications.Infrastructure.entity;

namespace transporte.src.modules.notification_type.Infrastructure.entity;

public sealed class NotificationTypeEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<NotificationsEntity> Notifications { get; set; } = new List<NotificationsEntity>();
}
