namespace Verico.Core.ValueObjects;

public sealed record TransactionAmount
{
    public decimal Value { get; }

    public TransactionAmount(decimal value)
    {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        Value = value;
    }

    public static implicit operator decimal(TransactionAmount transactionAmount)
        => transactionAmount.Value;

    public static implicit operator TransactionAmount(decimal transactionAmount)
        => new(transactionAmount);
}