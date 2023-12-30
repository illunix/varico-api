namespace Verico.Core.Entities;

public sealed class Transaction
{
    public TransactionId? Id { get; init; }
    public TransactionReferenceId ReferenceId { get; private init; } = TransactionReferenceId.Create();
    public TransactionAmount Amount { get; private init; } = null!;
    public TransactionCategory Category { get; private set; } = null!;
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public AggregateId AccountId { get; private set; } = null!;
    public Account? Account { get; init; }

    private Transaction() { }

    public Transaction(
        AggregateId accId,
        TransactionCategory category,
        TransactionAmount amount
    )
    {
        if (accId is null)
            throw new ArgumentNullException(nameof(accId));

        if (category is null)
            throw new ArgumentNullException(nameof(category));

        if (amount is null) 
            throw new ArgumentNullException(nameof(amount));

        AccountId = accId;
        Category = category;
        Amount = amount;
    }

    public void ChangeCategory(TransactionCategory category)
        => Category = category;
}