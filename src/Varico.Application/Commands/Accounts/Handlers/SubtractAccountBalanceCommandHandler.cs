namespace Varico.Application.Commands.Accounts.Handlers;

internal sealed class SubtractAccountBalanceCommandHandler(IAccountsRepository repo) : ICommandHandler<SubtractAccountBalanceCommand>
{
    public async ValueTask<Unit> Handle(
        SubtractAccountBalanceCommand cmd,
        CancellationToken ct
    )
    {
        cmd.Account.SubtractFromBalance(cmd.Amount);

        await repo
            .UpdateAsync(cmd.Account)
            .ConfigureAwait(false);
        
        return Unit.Value;
    }
}