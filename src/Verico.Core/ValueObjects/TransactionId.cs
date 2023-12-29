namespace Verico.Core.ValueObjects;

public sealed record TransactionId
{
    public int Value { get; }

    public TransactionId(int value)
        => Value = value;

    public static implicit operator int(TransactionId id)
        => id.Value;

    public static implicit operator TransactionId(decimal id)
        => new(id);
}