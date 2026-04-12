using transporte.src.modules.payments.Infrastructure.entity;

namespace transporte.src.modules.payment_statuses.Infrastructure.entity;

public sealed class PaymentStatusesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<PaymentsEntity> Payments { get; set; } = new List<PaymentsEntity>();
}
