using transporte.src.modules.credit_wallet.Infrastructure.entity;
using transporte.src.modules.transaction_types.Infrastructure.entity;

namespace transporte.src.modules.credit_transactions.Infrastructure.entity;

public sealed class CreditTransactionsEntity
{
    public Guid Id { get; set; }

    public Guid CreditWalletId { get; set; }

    public Guid TransactionTypeId { get; set; }

    public decimal Amount { get; set; }

    public DateTime CreatedAt { get; set; }

    public CreditWalletEntity CreditWallet { get; set; } = null!;

    public TransactionTypesEntity TransactionType { get; set; } = null!;
}
