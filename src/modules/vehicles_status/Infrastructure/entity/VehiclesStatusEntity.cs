using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.vehicles_status.Infrastructure.entity;

public sealed class VehiclesStatusEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<VehiclesEntity> Vehicles { get; set; } = new List<VehiclesEntity>();
}
