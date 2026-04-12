using transporte.src.modules.loads.Infrastructure.entity;

namespace transporte.src.modules.load_status_history.Infrastructure.entity;

public sealed class LoadStatusHistoryEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public Guid LoadStatusId { get; set; }

    public DateTime ChangedAt { get; set; }

    public LoadsEntity Load { get; set; } = null!;
}
