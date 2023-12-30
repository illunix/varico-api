namespace Varico.Application.DTOs.Accounts;

public sealed record AccountTransactionDto(
    string ReferenceId,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);