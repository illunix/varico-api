namespace Verico.Core.Entities;

public sealed class Transaction : EntityBase
{
    public TransactionAmount Amount { get; private set; } = null!;
    public TransactionCategory Category { get; private set; } = null!;
}