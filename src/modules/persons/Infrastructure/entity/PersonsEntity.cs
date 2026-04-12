using transporte.src.modules.audit_log.Infrastructure.entity;
using transporte.src.modules.documents_customers.Infrastructure.entity;
using transporte.src.modules.auth_credentials.Infrastructure.entity;
using transporte.src.modules.auth_sessions.Infrastructure.entity;
using transporte.src.modules.chat_messages.Infrastructure.entity;
using transporte.src.modules.chat_participants.Infrastructure.entity;
using transporte.src.modules.credit_wallet.Infrastructure.entity;
using transporte.src.modules.disputes.Infrastructure.entity;
using transporte.src.modules.drivers.Infrastructure.entity;
using transporte.src.modules.loads.Infrastructure.entity;
using transporte.src.modules.notifications.Infrastructure.entity;
using transporte.src.modules.person_plans.Infrastructure.entity;
using transporte.src.modules.person_roles.Infrastructure.entity;
using transporte.src.modules.person_status.Infrastructure.entity;
using transporte.src.modules.person_transport.Infrastructure.entity;
using transporte.src.modules.ratings.Infrastructure.entity;
using transporte.src.modules.subscriptions.Infrastructure.entity;
using transporte.src.modules.transport_companies.Infrastructure.entity;
using transporte.src.modules.vehicles.Infrastructure.entity;

namespace transporte.src.modules.persons.Infrastructure.entity;

public sealed class PersonsEntity
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string IdNum { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public Guid PersonStatusId { get; set; }

    public Guid? CompanyId { get; set; }

    public DateTime CreatedAt { get; set; }

    public PersonStatusEntity PersonStatus { get; set; } = null!;

    public TransportCompaniesEntity? Company { get; set; }

    public ICollection<AuthCredentialsEntity> AuthCredentials { get; set; } = new List<AuthCredentialsEntity>();

    public ICollection<AuthSessionsEntity> AuthSessions { get; set; } = new List<AuthSessionsEntity>();

    public ICollection<CreditWalletEntity> CreditWallets { get; set; } = new List<CreditWalletEntity>();

    public ICollection<NotificationsEntity> Notifications { get; set; } = new List<NotificationsEntity>();

    public ICollection<LoadsEntity> LoadsAsCustomer { get; set; } = new List<LoadsEntity>();

    public ICollection<DriversEntity> Drivers { get; set; } = new List<DriversEntity>();

    public ICollection<ChatParticipantsEntity> ChatParticipations { get; set; } = new List<ChatParticipantsEntity>();

    public ICollection<ChatMessagesEntity> SentChatMessages { get; set; } = new List<ChatMessagesEntity>();

    public ICollection<AuditLogEntity> AuditLogs { get; set; } = new List<AuditLogEntity>();

    public ICollection<PersonRolesEntity> PersonRoles { get; set; } = new List<PersonRolesEntity>();

    public ICollection<PersonPlansEntity> PersonPlans { get; set; } = new List<PersonPlansEntity>();

    public ICollection<SubscriptionsEntity> Subscriptions { get; set; } = new List<SubscriptionsEntity>();

    public ICollection<PersonTransportEntity> PersonTransportLinks { get; set; } = new List<PersonTransportEntity>();

    public ICollection<RatingsEntity> RatingsGiven { get; set; } = new List<RatingsEntity>();

    public ICollection<RatingsEntity> RatingsReceived { get; set; } = new List<RatingsEntity>();

    public ICollection<DocumentsCustomersEntity> DocumentsCustomers { get; set; } = new List<DocumentsCustomersEntity>();

    public ICollection<VehiclesEntity> OwnedVehicles { get; set; } = new List<VehiclesEntity>();

    public ICollection<TransportCompaniesEntity> CompaniesAsLegalRepresentative { get; set; } = new List<TransportCompaniesEntity>();

    public ICollection<DisputesEntity> DisputesReported { get; set; } = new List<DisputesEntity>();
}
