using transporte.src.modules.person_plans.Infrastructure.entity;
using transporte.src.modules.price_history.Infrastructure.entity;
using transporte.src.modules.subscriptions.Infrastructure.entity;

namespace transporte.src.modules.plans.Infrastructure.entity;

public sealed class PlansEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string BillingPeriod { get; set; } = string.Empty;

    public ICollection<PersonPlansEntity> PersonPlans { get; set; } = new List<PersonPlansEntity>();

    public ICollection<SubscriptionsEntity> Subscriptions { get; set; } = new List<SubscriptionsEntity>();

    public ICollection<PriceHistoryEntity> PriceHistories { get; set; } = new List<PriceHistoryEntity>();
}
