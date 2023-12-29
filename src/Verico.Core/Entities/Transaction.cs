namespace Verico.Core.Entities;

public sealed class Transaction(
    AggregateId id,
    TransactionCategory category,
    TransactionAmount amount
)
{
    public TransactionReferenceId ReferenceId { get; private init; } = TransactionReferenceId.Create();
    public TransactionAmount Amount { get; private init; } = amount;
    public TransactionCategory Category { get; private set; } = category;
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public AggregateId AccountId { get; private set; } = id;
    public Account? Account { get; init; }

    public void ChangeCategory(TransactionCategory category)
        => Category = category;
}