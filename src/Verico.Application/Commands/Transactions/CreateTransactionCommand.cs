namespace Verico.Application.Commands.Transactions;

public sealed record CreateTransactionCommand(
    [property: JsonIgnore] Guid AccountReferenceId,
    string Category,
    decimal Amount
);