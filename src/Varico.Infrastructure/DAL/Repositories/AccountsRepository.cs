namespace Varico.Infrastructure.DAL.Repositories;

internal sealed class AccountsRepository(VaricoDbContext ctx) : IAccountsRepository
{
    public Task<AggregateId?> GetIdAsync(
        Guid referenceId,
        CancellationToken ct = default
    )
        => ctx.Accounts
            .Where(q => q.ReferenceId.Equals(referenceId))
            .Select(q => q.Id)
            .FirstOrDefaultAsync(ct);
}