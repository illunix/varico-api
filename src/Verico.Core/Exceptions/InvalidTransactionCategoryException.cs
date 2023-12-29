namespace Verico.Core.Exceptions;

internal sealed class InvalidTransactionCategoryException(string category) : Exception($"Invalid transaction category: '{category}'");