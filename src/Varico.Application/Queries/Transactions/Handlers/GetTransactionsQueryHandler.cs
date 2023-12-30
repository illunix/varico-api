namespace Varico.Application.Queries.Transactions.Handlers;

public sealed class GetTransactionsQueryHandler(ITransactionsRepository repo)
{
    public async Task<IEnumerable<TransactionDto>> Handle(
        GetTransactionsQuery qry,
        CancellationToken ct
    )
        => (await repo.GetAsync(
                ConstructFilterExpression(qry),
                ct
            )).Select(q => new TransactionDto(
                q.ReferenceId,
                new(
                    q.Account?.ReferenceId!,
                    q.Account?.FullName!
                ),
                q.Amount,
                q.Category,
                q.CreatedAt
            ));

    private Expression<Func<Transaction, bool>> ConstructFilterExpression(GetTransactionsQuery qry)
    {
        var predicate = PredicateBuilder.True<Transaction>();

        if (
            qry.AccountReferenceId is not null &&
            qry.AccountReferenceId != Guid.Empty
        )
            predicate = predicate.And(q => q.Account!.ReferenceId.Equals(qry.AccountReferenceId));

        if (!string.IsNullOrEmpty(qry.Category))
            predicate = predicate.And(q => q.Category.Equals(qry.Category));

        return predicate;
    }
}