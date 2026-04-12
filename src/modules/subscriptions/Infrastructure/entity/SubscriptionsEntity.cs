using transporte.src.modules.payments.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.plans.Infrastructure.entity;
using transporte.src.modules.subscription_status.Infrastructure.entity;
using transporte.src.modules.subscription_type.Infrastructure.entity;

namespace transporte.src.modules.subscriptions.Infrastructure.entity;

public sealed class SubscriptionsEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public Guid PlanId { get; set; }

    public Guid SubscriptionStatusId { get; set; }

    public Guid SubscriptionTypeId { get; set; }

    public Guid? PaymentId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public PlansEntity Plan { get; set; } = null!;

    public SubscriptionStatusEntity SubscriptionStatus { get; set; } = null!;

    public SubscriptionTypeEntity SubscriptionType { get; set; } = null!;

    public PaymentsEntity? Payment { get; set; }
}
