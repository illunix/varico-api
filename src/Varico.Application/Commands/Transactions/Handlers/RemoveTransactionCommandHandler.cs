namespace Varico.Application.Commands.Transactions.Handlers;

internal sealed class RemoveTransactionCommandHandler(ITransactionsRepository repo) : ICommandHandler<RemoveTransactionCommand>
{
    public async ValueTask<Unit> Handle(
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

        return Unit.Value;
    }
}