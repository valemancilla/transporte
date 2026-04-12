using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.auth_credentials.Infrastructure.entity;

public sealed class AuthCredentialsEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public DateTime? LastLogin { get; set; }

    public int FailedAttempts { get; set; }

    public bool IsActive { get; set; }

    public PersonsEntity Person { get; set; } = null!;
}
