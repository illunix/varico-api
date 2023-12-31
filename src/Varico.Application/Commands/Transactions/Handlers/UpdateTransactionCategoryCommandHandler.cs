namespace Varico.Application.Commands.Transactions.Handlers;

internal sealed class UpdateTransactionCategoryCommandHandler(ITransactionsRepository repo) : ICommandHandler<UpdateTransactionCategoryCommand>
{
    public async ValueTask<Unit> Handle(
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

        return Unit.Value;
    }
}