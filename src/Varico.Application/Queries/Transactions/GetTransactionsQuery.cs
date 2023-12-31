namespace Varico.Application.Queries.Transactions;

public sealed record GetTransactionsQuery(
    string? AccountReferenceId,
    string? Category
) : IQuery<IEnumerable<TransactionDto>>;