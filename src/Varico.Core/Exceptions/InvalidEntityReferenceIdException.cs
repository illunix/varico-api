namespace Varico.Core.Exceptions;

internal sealed class InvalidEntityReferenceIdException(Guid referenceId) : ExceptionBase($"Cannot set: {referenceId}  as entity reference identifier.") { }