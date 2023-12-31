namespace Varico.Infrastructure.DAL.Initializers;

internal sealed class AccountsInitializer(
    VaricoDbContext ctx,
    ILogger<AccountsInitializer> logger
) : IDataInitializer
{
    public async Task InitAsync()
    {
        if (await ctx.Accounts.AnyAsync())
            return;

        await AddAccounts().ConfigureAwait(false);
        await ctx
            .SaveChangesAsync()
            .ConfigureAwait(false);
    }

    private async Task AddAccounts()
    {
        await ctx.Accounts.AddRangeAsync(
            new Account(
                new(
                    "Jan",
                    "Kowalski"
                ),
                new((decimal)1900.83)
            ),
            new Account(
                new(
                    "Amir",
                    "Czarnecki"
                ),
                new((decimal)9583.00)
            ),
            new Account(
                new(
                    "Izabela",
                    "Błaszczyk"
                ),
                new((decimal)3568.71)
            ),
            new Account(
                new(
                    "Franciszek",
                    "Jankowski"
                ),
                new((decimal)498.13)
            )
        ).ConfigureAwait(false);

        logger.LogInformation("Initialized accounts.");
    }
}