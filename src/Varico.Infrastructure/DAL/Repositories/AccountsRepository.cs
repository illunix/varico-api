namespace Varico.Infrastructure.DAL.Repositories;

internal sealed class AccountsRepository(VaricoDbContext ctx) : IAccountsRepository
{
    public Task<AggregateId?> GetIdAsync(
        string referenceId,
        CancellationToken ct = default
    )
        => ctx.Accounts
            .Where(q => q.ReferenceId.Equals(referenceId))
            .Select(q => q.Id)
            .FirstOrDefaultAsync(ct);

    public Task<Account?> GetByAsync(
        string referenceId,
        CancellationToken ct = default
    )
        => ctx.Accounts
            .Where(q => q.ReferenceId.Equals(referenceId))
            .Include(q => q.Transactions)
            .FirstOrDefaultAsync(ct);

    public async Task<IEnumerable<Account>> GetAsync(CancellationToken ct = default)
       => await ctx.Accounts
            .AsNoTracking()
            .ToListAsync(ct)
            .ConfigureAwait(false);

    public async Task UpdateAsync(
        Account acc,
        CancellationToken ct = default
    )
    {
        ctx.Accounts.Update(acc);

        await ctx
            .SaveChangesAsync(ct)
            .ConfigureAwait(false);
    }
}