namespace Verico.Core.Entities.Abstractions;

public class EntityBase
{
    public int Id { get; init; }
    public Guid ReferenceId { get; private set; } = Guid.NewGuid();
}