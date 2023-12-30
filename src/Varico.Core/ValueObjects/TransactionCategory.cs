using System.Collections.Immutable;

namespace Varico.Core.ValueObjects;

public sealed record TransactionCategory
{
    public string Value { get; }

    public const string Food = nameof(Food);
    public const string Entertainment = nameof(Entertainment);
    public const string Bills = nameof(Bills);
    public const string Other = nameof(Other);
    public const string Unknown = nameof(Unknown);

    private readonly ImmutableHashSet<string> ValidCategories = [Food, Entertainment, Bills, Other];

    public TransactionCategory(string value)
    {
        if (!ValidCategories.Contains(value))
            throw new InvalidTransactionCategoryException(value);

        Value = value;
    }

    public static implicit operator string(TransactionCategory transactionCategory)
        => transactionCategory.Value;

    public static implicit operator TransactionCategory(string transactionCategory)
        => new(transactionCategory);
}