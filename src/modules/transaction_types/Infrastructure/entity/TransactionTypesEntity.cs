using transporte.src.modules.credit_transactions.Infrastructure.entity;

namespace transporte.src.modules.transaction_types.Infrastructure.entity;

public sealed class TransactionTypesEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<CreditTransactionsEntity> CreditTransactions { get; set; } = new List<CreditTransactionsEntity>();
}
