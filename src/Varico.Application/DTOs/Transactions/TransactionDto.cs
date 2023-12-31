namespace Varico.Application.DTOs.Transactions;

public sealed record TransactionDto(
    string ReferenceId,
    TransactionAccountDto Account,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);