namespace Varico.Application.Queries.Common.Handlers;

public sealed class GetTransactionCategoriesQueryHandler : IQueryHandler<GetTransactionCategoriesQuery, IEnumerable<string>>
{
    public async ValueTask<IEnumerable<string>> Handle(
        GetTransactionCategoriesQuery qry, 
        CancellationToken ct
    )
        => await Task.FromResult(new List<string>() {
                TransactionCategory.Bills,
                TransactionCategory.Entertainment,
                TransactionCategory.Food,
                TransactionCategory.Other
        });
}