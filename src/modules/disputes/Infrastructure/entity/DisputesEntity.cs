using transporte.src.modules.dispute_status.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;
using transporte.src.modules.reason_disputes.Infrastructure.entity;
using transporte.src.modules.trips.Infrastructure.entity;

namespace transporte.src.modules.disputes.Infrastructure.entity;

public sealed class DisputesEntity
{
    public Guid Id { get; set; }

    public Guid TripId { get; set; }

    public Guid ReporterPersonId { get; set; }

    public Guid DisputeStatusId { get; set; }

    public Guid ReasonDisputesId { get; set; }

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; }

    public TripsEntity Trip { get; set; } = null!;

    public PersonsEntity Reporter { get; set; } = null!;

    public DisputeStatusEntity DisputeStatus { get; set; } = null!;

    public ReasonDisputesEntity ReasonDispute { get; set; } = null!;
}
