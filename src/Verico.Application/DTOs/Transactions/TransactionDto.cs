namespace Verico.Application.DTOs.Transactions;

public sealed record TransactionDto(
    string CustomerFullName,
    decimal Amount,
    string Category,
    DateTime CreatedAt
);