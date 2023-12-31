namespace Varico.Core.ValueObjects;

public record TransactionReferenceId
{
    public string Value { get; }

    public TransactionReferenceId(string value)
    {
        Value = value;
    }

    public static TransactionReferenceId Create() => new(ShortId.Generate());

    public static implicit operator string(TransactionReferenceId date)
        => date.Value;

    public static implicit operator TransactionReferenceId(string value)
        => new(value);
}