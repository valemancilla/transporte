using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.person_status.Infrastructure.entity;

public sealed class PersonStatusEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<PersonsEntity> Persons { get; set; } = new List<PersonsEntity>();
}
