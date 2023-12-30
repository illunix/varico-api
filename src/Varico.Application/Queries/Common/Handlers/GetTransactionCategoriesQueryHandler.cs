namespace Varico.Application.Queries.Common.Handlers;

public sealed class GetTransactionCategoriesQueryHandler
{
    public IEnumerable<string> Handle()
        => [
                TransactionCategory.Bills,
                TransactionCategory.Entertainment,
                TransactionCategory.Food,
                TransactionCategory.Other
           ];
}