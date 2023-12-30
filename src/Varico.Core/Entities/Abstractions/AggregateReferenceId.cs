namespace Varico.Core.Entities.Abstractions;

public sealed record AggregateReferenceId
{
    public Guid Value { get; }

    public AggregateReferenceId(Guid value)
    {
        if (value == Guid.Empty)
            throw new InvalidEntityReferenceIdException(value);

        Value = value;
    }

    public static AggregateReferenceId Create() => new(Guid.NewGuid());

    public static implicit operator Guid(AggregateReferenceId date)
        => date.Value;

    public static implicit operator AggregateReferenceId(Guid value)
        => new(value);
}