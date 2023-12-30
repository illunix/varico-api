namespace Verico.Core.Exceptions;

internal sealed class InvalidTransactionCategoryException(string category) : ExceptionBase($"Invalid transaction category: '{category}'");