using transporte.src.modules.loads.Infrastructure.entity;

namespace transporte.src.modules.type_load.Infrastructure.entity;

public sealed class TypeLoadEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<LoadsEntity> Loads { get; set; } = new List<LoadsEntity>();
}
