namespace Varico.Infrastructure.DAL.Repositories;

internal sealed class TransactionsRepository(VaricoDbContext ctx) : ITransactionsRepository
{
    public async Task AddAsync(
        Transaction user,
        CancellationToken ct = default
    )
    {
        ctx.Transactions.Add(user);
        
        await ctx
            .SaveChangesAsync(ct)
            .ConfigureAwait(false);
    }
    
    public Task<Transaction?> GetByAsync(
        string referenceId,
        CancellationToken ct = default
    )
        => ctx.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(
                q => q.ReferenceId.Equals(referenceId),
                ct
            );

    public async Task<IEnumerable<Transaction>> GetAsync(
        Expression<Func<Transaction, bool>> predicate,
        CancellationToken ct = default
    )
       => await ctx.Transactions
            .AsNoTracking()
            .Include(q => q.Account)
            .Where(predicate)
            .ToListAsync(ct)
            .ConfigureAwait(false);
    
    public async Task UpdateAsync(
        Transaction user,
        CancellationToken ct = default
    )
    {
        ctx.Transactions.Update(user);

        await ctx
            .SaveChangesAsync(ct)
            .ConfigureAwait(false);
    }

    public async Task RemoveAsync(
        Transaction user,
        CancellationToken ct = default
    )
    {
        ctx.Transactions.Remove(user);

        await ctx
            .SaveChangesAsync(ct)
            .ConfigureAwait(false);
    }
}