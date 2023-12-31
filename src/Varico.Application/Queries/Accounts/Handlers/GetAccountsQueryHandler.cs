namespace Varico.Application.Queries.Accounts.Handlers;

internal sealed class GetAccountsQueryHandler(IAccountsRepository repo) : IQueryHandler<GetAccountsQuery, IEnumerable<AccountDto>>
{
    public async ValueTask<IEnumerable<AccountDto>> Handle(
        GetAccountsQuery qry,
        CancellationToken ct
    )
        => (await repo
            .GetAsync(ct)
            .ConfigureAwait(false)
        ).Select(q => new AccountDto(
            q.ReferenceId, 
            q.FullName.Value
        ));
}