namespace Varico.Application.Commands.Accounts;

public sealed record SubtractAccountBalanceCommand(
    Account Account,
    decimal Amount
) : ICommand;