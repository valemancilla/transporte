using transporte.src.modules.subscriptions.Infrastructure.entity;

namespace transporte.src.modules.subscription_type.Infrastructure.entity;

public sealed class SubscriptionTypeEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<SubscriptionsEntity> Subscriptions { get; set; } = new List<SubscriptionsEntity>();
}
