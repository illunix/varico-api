namespace Varico.Application.Commands.Transactions.Handlers;

public sealed class UpdateTransactionCategoryCommandHandler(ITransactionsRepository repo) 
{
    public async Task Handle(
        UpdateTransactionCategoryCommand cmd,
        CancellationToken ct
    )
    {
        var transaction = await repo.GetByAsync(
            cmd.TransactionReferenceId,
            ct
        );
        if (transaction is null)
            throw new EntityNotFoundException(
                nameof(Transaction),
                cmd.TransactionReferenceId
            );
        
        transaction.ChangeCategory(cmd.Category);
        
        await repo.UpdateAsync(
            transaction,
            ct
        );
    }
}