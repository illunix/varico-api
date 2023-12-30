namespace Varico.Application.Commands.Transactions.Handlers;

public sealed class CreateTransactionCommandHandler(
    IAccountsRepository accountsRepo,
    ITransactionsRepository transactionsRepo
) 
{
    public async Task Handle(
        CreateTransactionCommand cmd,
        CancellationToken ct
    )
    {
        var accId = await accountsRepo.GetIdAsync(
            cmd.AccountReferenceId,
            ct
        );
        if (accId is null)
            throw new EntityNotFoundException(
                nameof(Account),
                cmd.AccountReferenceId
            );
        
        await transactionsRepo.AddAsync(
            new(
                accId,
                cmd.Category,
                cmd.Amount
            ),
            ct
        );
    }
}