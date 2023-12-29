namespace Verico.Core.Exceptions;

public sealed class InvalidEntityReferenceIdException(Guid referenceId) : ExceptionBase($"Cannot set: {referenceId}  as entity reference identifier.") { }