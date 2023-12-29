namespace Verico.Application.Commands.Transactions;

public sealed record ChangeTransactionCategoryCommand(
    [property: JsonIgnore] Guid TransactionReferenceId,
    string Category
);