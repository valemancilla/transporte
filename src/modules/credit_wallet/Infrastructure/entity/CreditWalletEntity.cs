using transporte.src.modules.credit_transactions.Infrastructure.entity;
using transporte.src.modules.payments.Infrastructure.entity;
using transporte.src.modules.persons.Infrastructure.entity;

namespace transporte.src.modules.credit_wallet.Infrastructure.entity;

public sealed class CreditWalletEntity
{
    public Guid Id { get; set; }

    public Guid PersonId { get; set; }

    public decimal Balance { get; set; }

    public DateTime LastUpdate { get; set; }

    public PersonsEntity Person { get; set; } = null!;

    public ICollection<CreditTransactionsEntity> CreditTransactions { get; set; } = new List<CreditTransactionsEntity>();

    public ICollection<PaymentsEntity> Payments { get; set; } = new List<PaymentsEntity>();
}
