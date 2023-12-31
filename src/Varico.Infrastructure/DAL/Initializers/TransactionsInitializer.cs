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
        
        var rngAccId = () => accountIds[rng.Next(accountIds.Count)];

        await ctx.Transactions.AddRangeAsync(
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)60.88
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)18.29
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)46.27
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)62.66
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)33.63
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)80.91
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)62.47
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)40.06
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)62.5
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)73.67
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Bills,
                (decimal)64.56
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)98.83
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)94.54
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)73.62
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)42.79
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)55.47
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)32.83
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Bills,
                (decimal)77.4
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)42.11
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)25.85
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)11.89
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)64.23
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)60.36
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Entertainment,
                (decimal)76.39
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Other,
                (decimal)38.93
            ),
            new Transaction(
                rngAccId(),
                TransactionCategory.Food,
                (decimal)26.2
            )
        ).ConfigureAwait(false);

        logger.LogInformation("Initialized transactions.");
    }
}