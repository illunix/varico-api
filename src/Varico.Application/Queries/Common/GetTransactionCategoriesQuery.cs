namespace Varico.Application.Queries.Common;

public sealed record GetTransactionCategoriesQuery : IQuery<IEnumerable<string>>;