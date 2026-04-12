using transporte.src.modules.person_roles.Infrastructure.entity;

namespace transporte.src.modules.roles.Infrastructure.entity;

public sealed class RolesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<PersonRolesEntity> PersonRoles { get; set; } = new List<PersonRolesEntity>();
}
