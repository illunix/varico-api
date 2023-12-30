namespace Varico.Infrastructure.DAL.Initializers;

internal sealed class TransactionsInitializer(
    VaricoDbContext ctx,
    ILogger<AccountsInitializer> logger
) : IDataInitializer
{
    public async Task InitAsync()
    {
        if (await ctx.Transactions.AnyAsync())
            return;

        await AddTransactions().ConfigureAwait(false);
        await ctx
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }

    private async Task AddTransactions()
    {
        var accountIds = await ctx.Accounts
            .Select(q => q.Id)
            .ToListAsync()
            .ConfigureAwait(false);

        var rng = new Random();

        await ctx.Transactions.AddRangeAsync(
            new Transaction(
                accountIds[rng.Next(accountIds.Count)],
                TransactionCategory.Bills,
                (decimal)25.99
            ),
            
        ).ConfigureAwait(false);

        logger.LogInformation("Initialized transactions.");
    }
}