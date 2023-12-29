namespace Verico.Core.ValueObjects;

public record TransactionReferenceId
{
    public Guid Value { get; }

    public TransactionReferenceId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityReferenceIdException(value);

        Value = value;
    }

    public static TransactionReferenceId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(TransactionReferenceId date)
        => date.Value;

    public static implicit operator TransactionReferenceId(Guid value)
        => new(value);
}