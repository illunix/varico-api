namespace Varico.Core.Exceptions;

public sealed class EntityNotFoundException : ExceptionBase
{
    public EntityNotFoundException(
        string name,
        Guid referenceId
    ) : base($"{name} with Reference ID: '{referenceId}' was not found.") { }
}