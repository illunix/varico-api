namespace Varico.Application.Commands.Transactions;

public sealed record UpdateTransactionCategoryCommand(
    [property: JsonIgnore] string TransactionReferenceId,
    string Category
);