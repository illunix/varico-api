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
            new Account(new(
                "Jan",
                "Kowalski"
            )),
            new Account(new(
                "Amir",
                "Czarnecki"
            )),
            new Account(new(
                "Izabela",
                "Błaszczyk"
            )),
            new Account(new(
                "Franciszek",
                "Jankowski"
            ))
        ).ConfigureAwait(false);

        logger.LogInformation("Initialized accounts.");
    }
}