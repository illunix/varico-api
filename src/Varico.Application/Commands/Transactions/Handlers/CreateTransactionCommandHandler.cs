namespace Varico.Application.Commands.Transactions.Handlers;

internal sealed class CreateTransactionCommandHandler(
    IAccountsRepository accountsRepo,
    ITransactionsRepository transactionsRepo,
    IMediator mediator
) : ICommandHandler<CreateTransactionCommand> 
{
    public async ValueTask<Unit> Handle(
        CreateTransactionCommand cmd,
        CancellationToken ct
    )
    {
        var acc = await accountsRepo.GetByAsync(
            cmd.AccountReferenceId,
            ct
        );
        if (acc is null)
            throw new EntityNotFoundException(
                nameof(Account),
                cmd.AccountReferenceId
            );

        await transactionsRepo
            .AddAsync(
                new(
                    acc.Id,
                    cmd.Category,
                    cmd.Amount
                ),
                ct
            )
            .ConfigureAwait(false);

        await mediator
            .Publish(
                new CreatedTransactionEvent(
                    acc,
                    cmd.Amount
                ),
                ct
            )
            .ConfigureAwait(false);

        return Unit.Value;
    }
}