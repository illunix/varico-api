namespace Varico.Application.DTOs.Accounts;

public sealed record AccountSummaryDto(
    string FullName,
    decimal Balance,
    decimal TotalAmountSpent,
    IEnumerable<AccountTransactionDto> Transactions 
);