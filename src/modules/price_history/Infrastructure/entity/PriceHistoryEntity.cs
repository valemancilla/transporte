using transporte.src.modules.plans.Infrastructure.entity;

namespace transporte.src.modules.price_history.Infrastructure.entity;

public sealed class PriceHistoryEntity
{
    public Guid Id { get; set; }

    public Guid PlanId { get; set; }

    public decimal Amount { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }

    public PlansEntity Plan { get; set; } = null!;
}
