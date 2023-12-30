namespace Varico.Application.Commands.Transactions.Handlers;

public sealed class RemoveTransactionCommandHandler(ITransactionsRepository repo)
{
    public async Task Handle(
        RemoveTransactionCommand cmd,
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

        await repo.RemoveAsync(transaction);
    }
}