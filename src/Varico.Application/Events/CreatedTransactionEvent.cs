namespace Varico.Application.Events;

public sealed record CreatedTransactionEvent(
    Account Account,
    decimal Amount
) : INotification;