namespace Varico.Application.Queries.Transactions;

public sealed record GetTransactionsQuery(
    Guid? AccountReferenceId,
    string? Category
);