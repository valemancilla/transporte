using transporte.src.modules.disputes.Infrastructure.entity;

namespace transporte.src.modules.reason_disputes.Infrastructure.entity;

public sealed class ReasonDisputesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<DisputesEntity> Disputes { get; set; } = new List<DisputesEntity>();
}
