using transporte.src.modules.disputes.Infrastructure.entity;

namespace transporte.src.modules.dispute_status.Infrastructure.entity;

public sealed class DisputeStatusEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<DisputesEntity> Disputes { get; set; } = new List<DisputesEntity>();
}
