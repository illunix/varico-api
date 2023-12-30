namespace Varico.Application.DTOs.Accounts;

public sealed record AccountSummaryDto(
    string FullName,
    decimal TotalAmountSpent,
    IEnumerable<AccountTransactionDto> Transactions 
);