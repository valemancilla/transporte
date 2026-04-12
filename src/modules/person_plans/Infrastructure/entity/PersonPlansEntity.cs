using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.plans.Infrastructure.entity;

namespace transporte.src.modules.person_plans.Infrastructure.entity;

public sealed class PersonPlansEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public Guid PlanId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public PlansEntity Plan { get; set; } = null!;
}
