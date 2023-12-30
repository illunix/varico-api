namespace Varico.Application.DTOs.Accounts;

public sealed record AccountTransactionDto(
    Guid ReferenceId,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);