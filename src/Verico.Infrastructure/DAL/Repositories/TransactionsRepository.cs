namespace Verico.Infrastructure.DAL.Repositories;

internal sealed class TransactionsRepository(VericoDbContext ctx) : ITransactionsRepository
{
    public async Task AddAsync(
        Transaction user,
        CancellationToken ct = default
    )
    {
        ctx.Transactions.Add(user);
        
        await ctx.SaveChangesAsync(ct);
    }
    
    public Task<Transaction?> GetAsync(
        string referenceId,
        CancellationToken ct = default
    )
        => ctx.Transactions
            .AsNoTracking()
            .FirstOrDefaultAsync(
                q => q.ReferenceId.Equals(referenceId),
                ct
            );
    
    public async Task UpdateAsync(
        Transaction user,
        CancellationToken ct = default
    )
    {
        ctx.Transactions.Update(user);

        await ctx.SaveChangesAsync(ct);
    }
}