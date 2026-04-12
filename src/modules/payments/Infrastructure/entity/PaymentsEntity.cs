using transporte.src.modules.credit_wallet.Infrastructure.entity;
using transporte.src.modules.payment_providers.Infrastructure.entity;
using transporte.src.modules.payment_statuses.Infrastructure.entity;
using transporte.src.modules.subscriptions.Infrastructure.entity;

namespace transporte.src.modules.payments.Infrastructure.entity;

public sealed class PaymentsEntity
{
    public Guid Id { get; set; }

    public Guid WalletId { get; set; }

    public Guid PaymentProviderId { get; set; }

    public Guid PaymentStatusId { get; set; }

    public string ExternalReference { get; set; } = string.Empty;

    public decimal AmountMoney { get; set; }

    public DateTime CreatedAt { get; set; }

    public CreditWalletEntity Wallet { get; set; } = null!;

    public PaymentProvidersEntity PaymentProvider { get; set; } = null!;

    public PaymentStatusesEntity PaymentStatus { get; set; } = null!;

    public ICollection<SubscriptionsEntity> Subscriptions { get; set; } = new List<SubscriptionsEntity>();
}
