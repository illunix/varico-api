namespace Varico.Application.Events.Handlers;

internal sealed class CreatedTransactionEventHandler(IMediator mediator) : INotificationHandler<CreatedTransactionEvent>
{
    public async ValueTask Handle(
        CreatedTransactionEvent @event,
        CancellationToken ct
    )
        => await mediator.Send(
            new SubtractAccountBalanceCommand(
                @event.Account,
                @event.Amount
            )
        );
}
