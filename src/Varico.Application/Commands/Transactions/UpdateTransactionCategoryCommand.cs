namespace Varico.Application.Commands.Transactions;

public sealed record UpdateTransactionCategoryCommand(
    [property: JsonIgnore] Guid TransactionReferenceId,
    string Category
);