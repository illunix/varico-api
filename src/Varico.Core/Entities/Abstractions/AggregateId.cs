namespace Varico.Core.Entities.Abstractions;

public sealed record AggregateId(int Value)
{
    public int Value { get; } = Value;

    public static implicit operator int(AggregateId id)
        => id.Value;

    public static implicit operator AggregateId(int id)
        => new(id);

    public override string ToString() => Value.ToString();
}