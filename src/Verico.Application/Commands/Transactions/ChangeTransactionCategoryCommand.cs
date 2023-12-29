namespace Verico.Application.Commands.Transactions;

public sealed record ChangeTransactionCategoryCommand(
    [property: JsonIgnore] string TransactionReferenceId,
    string Category
);