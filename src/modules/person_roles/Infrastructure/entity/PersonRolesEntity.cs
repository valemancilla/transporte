using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.roles.Infrastructure.entity;

namespace transporte.src.modules.person_roles.Infrastructure.entity;

public sealed class PersonRolesEntity
{
    public Guid PersonId { get; set; }

    public Guid RoleId { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public RolesEntity Role { get; set; } = null!;
}
