namespace Varico.Application.Commands.Accounts.Handlers;

internal sealed class SubtractAccountBalanceCommandHandler(IAccountsRepository repo) : ICommandHandler<SubtractAccountBalanceCommand>
{
    public async ValueTask<Unit> Handle(
        SubtractAccountBalanceCommand cmd,
        CancellationToken ct
    )
    {
        cmd.Account.Balance.Subtract(cmd.Amount);

        await repo.UpdateAsync(cmd.Account);
        
        return Unit.Value;
    }
}