﻿namespace Varico.Application.Queries.Accounts.Handlers;

public sealed class GetAccountSummaryQueryHandler(IAccountsRepository repo) : IQueryHandler<GetAccountSummaryQuery, AccountSummaryDto?>
{
    public async ValueTask<AccountSummaryDto?> Handle(
        GetAccountSummaryQuery qry,
        CancellationToken ct
    )
    {
        var acc = await repo
            .GetByAsync(
                qry.AccountReferenceId,
                ct
            )
            .ConfigureAwait(false);
        if (acc is null)
            return null;

        return new(
            acc.FullName.Value,
            acc.Balance,
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