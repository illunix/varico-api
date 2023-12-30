namespace Varico.Application.DTOs.Transactions;

public sealed record TransactionDto(
    Guid ReferenceId,
    AccountDto Account,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);