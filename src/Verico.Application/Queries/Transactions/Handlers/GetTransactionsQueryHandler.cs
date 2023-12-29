namespace Verico.Application.Queries.Transactions.Handlers;

public sealed class GetTransactionsQueryHandler(ITransactionsRepository repo)
{
    public async Task<IEnumerable<TransactionDto>> Handle(
        GetTransactionsQuery qry,
        CancellationToken ct
    )
        => (await repo.GetAsync(ct)).Select(q => new TransactionDto(
            q.Account?.FullName!,
            q.Amount,
            q.Category,
            q.CreatedAt
        ));
}