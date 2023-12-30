namespace Varico.Application.DTOs.Transactions;

public sealed record TransactionDto(
    string ReferenceId,
    AccountDto Account,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);