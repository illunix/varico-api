namespace Varico.Application.Queries.Accounts.Handlers;

public sealed class GetAccountSummaryQueryHandler(IAccountsRepository repo)
{
    public async Task<AccountSummaryDto?> Handle(
        GetAccountSummaryQuery qry,
        CancellationToken ct
    )
    {
        var acc = await repo.GetByAsync(
            qry.AccountReferenceId,
            ct
        );
        if (acc is null)
            return null;

        return new(
            acc.FullName.Value,
            acc.Transactions.Sum(q => q.Amount),
            acc.Transactions.Select(q => new AccountTransactionDto(
                q.ReferenceId,
                q.Amount,
                q.Category,
                q.CreatedAt
            ))
        );
    }
}