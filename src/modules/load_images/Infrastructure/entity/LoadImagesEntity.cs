using transporte.src.modules.loads.Infrastructure.entity;

namespace transporte.src.modules.load_images.Infrastructure.entity;

public sealed class LoadImagesEntity
{
    public Guid Id { get; set; }

    public Guid LoadId { get; set; }

    public string Url { get; set; } = string.Empty;

    public int SortOrder { get; set; }

    public LoadsEntity Load { get; set; } = null!;
}
