using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.auth_sessions.Infrastructure.entity;

public sealed class AuthSessionsEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string SessionToken { get; set; } = string.Empty;

    public DateTime ExpiresAt { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? IpAddress { get; set; }

    public PersonsEntity Person { get; set; } = null!;
}
