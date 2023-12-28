namespace Verico.Core.ValueObjects;

public sealed record TransactionCategory(string Value)
{
    public const string Food = nameof(Food);
    public const string Entertainment = nameof(Entertainment);
    public const string Bills = nameof(Bills);

    public static implicit operator string(TransactionCategory transactionCategory)
        => transactionCategory.Value;

    public static implicit operator TransactionCategory(string transactionCategory)
        => new(transactionCategory);
}