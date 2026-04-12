using transporte.src.modules.bids.Infrastructure.entity;

namespace transporte.src.modules.status_bids.Infrastructure.entity;

public sealed class StatusBidsEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<BidsEntity> Bids { get; set; } = new List<BidsEntity>();
}
