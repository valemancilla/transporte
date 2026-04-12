using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.audit_log.Infrastructure.entity;

public sealed class AuditLogEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string TableName { get; set; } = string.Empty;

    public Guid RecordId { get; set; }

    public string? OldValues { get; set; }

    public string? NewValues { get; set; }

    public string? IpAddress { get; set; }

    public string? UserAgent { get; set; }

    public DateTime CreatedAt { get; set; }

    public PersonsEntity Person { get; set; } = null!;
}
