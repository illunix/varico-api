namespace Varico.Core.Entities.Abstractions;

public sealed record AggregateReferenceId
{
    public string Value { get; }

    public AggregateReferenceId(string value)
    {
        Value = value;
    }

    public static AggregateReferenceId Create() => new(ShortId.Generate());

    public static implicit operator string(AggregateReferenceId date)
        => date.Value;

    public static implicit operator AggregateReferenceId(string value)
        => new(value);
}