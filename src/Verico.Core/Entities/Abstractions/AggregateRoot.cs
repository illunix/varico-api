namespace Verico.Core.Entities.Abstractions;

public abstract class AggregateRoot
{
    public AggregateId Id { get; protected set; } = null!;
    public AggregateReferenceId ReferenceId { get; private set; } = AggregateReferenceId.Create();
}