using transporte.src.modules.notification_type.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.notifications.Infrastructure.entity;

public sealed class NotificationsEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Body { get; set; } = string.Empty;

    public Guid NotificationTypeId { get; set; }

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public NotificationTypeEntity NotificationType { get; set; } = null!;
}
