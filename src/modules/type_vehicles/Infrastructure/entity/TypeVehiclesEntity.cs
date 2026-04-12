using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.type_vehicles.Infrastructure.entity;

public sealed class TypeVehiclesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<VehiclesEntity> Vehicles { get; set; } = new List<VehiclesEntity>();
}
