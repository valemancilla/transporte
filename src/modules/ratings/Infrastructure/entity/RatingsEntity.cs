using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.ratings.Infrastructure.entity;

public sealed class RatingsEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid RaterPersonId { get; set; }

    public Guid RatedPersonId { get; set; }

    public int Score { get; set; }

    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }

    public TripsEntity Trip { get; set; } = null!;

    public PersonsEntity RaterPerson { get; set; } = null!;

    public PersonsEntity RatedPerson { get; set; } = null!;
}
