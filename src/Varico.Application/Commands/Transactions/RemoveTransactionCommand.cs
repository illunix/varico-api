namespace Varico.Application.Commands.Transactions;

public sealed record RemoveTransactionCommand(string TransactionReferenceId) : ICommand;