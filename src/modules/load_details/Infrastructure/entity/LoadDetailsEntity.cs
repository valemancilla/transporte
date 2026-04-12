using transporte.src.modules.loads.Infrastructure.entity;

namespace transporte.src.modules.load_details.Infrastructure.entity;

public sealed class LoadDetailsEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public string DetailKey { get; set; } = string.Empty;

    public string DetailValue { get; set; } = string.Empty;

    public LoadsEntity Load { get; set; } = null!;
}
