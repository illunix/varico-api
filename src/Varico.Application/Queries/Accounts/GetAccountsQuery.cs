namespace Varico.Application.Queries.Accounts;

public sealed record GetAccountsQuery : IQuery<IEnumerable<AccountDto>>;