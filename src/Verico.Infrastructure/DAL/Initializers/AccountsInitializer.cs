namespace Verico.Infrastructure.DAL.Initializers;

internal sealed class AccountsInitializer(
    VericoDbContext ctx,
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
                "Jan",
                "Kowalski"
            ),
            new Account(
                "Amir",
                "Czarnecki"
            ),
            new Account(
                "Izabela",
                "Błaszczyk"
            ),
            new Account(
                "Franciszek",
                "Jankowski"
            )
        ).ConfigureAwait(false);

        logger.LogInformation("Initialized accounts.");
    }
}