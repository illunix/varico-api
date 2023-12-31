namespace Varico.Application.Commands.Transactions;

public sealed record CreateTransactionCommand(
    [property: JsonIgnore] string AccountReferenceId,
    string Category,
    decimal Amount
) : ICommand;