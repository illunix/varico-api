namespace Verico.Infrastructure.DAL.Repositories;

internal sealed class AccountsRepository(VericoDbContext ctx) : IAccountsRepository
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