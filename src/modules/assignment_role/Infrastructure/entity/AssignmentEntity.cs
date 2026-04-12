using transporte.src.modules.trip_assignments.Infrastructure.entity;

namespace transporte.src.modules.assignment_role.Infrastructure.entity;

public sealed class AssignmentEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<TripAssignmentEntity> TripAssignments { get; set; } = new List<TripAssignmentEntity>();
}
