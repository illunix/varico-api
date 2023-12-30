namespace Varico.Api.Endpoints;

internal static class AccountsEndpoints
{
    public static RouteGroupBuilder MapAccountsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("accounts");

        group.MapPost(
            "/{accountReferenceId}/transactions",
            CreateTransaction
        )
            .WithName("Create transaction")
            .Produces(StatusCodes.Status204NoContent)
            .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest);

        group.MapGet(
            "/{accountReferenceId}/summary",
            GetAccountSummary
        )
            .WithName("Get account summary")
            .Produces<AccountSummaryDto>()
            .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status404NotFound);

        group.WithTags("Accounts");

        return group;
    }

    private static async Task<IResult> CreateTransaction(
        Guid accountReferenceId,
        CreateTransactionCommand cmd,
        CreateTransactionCommandHandler handler,
        CancellationToken ct
    )
    {
        await handler.Handle(
            cmd with { AccountReferenceId = accountReferenceId },
            ct
        );

        return Results.NoContent();
    }

    private static async Task<IResult> GetAccountSummary(
        Guid accountReferenceId,
        GetAccountSummaryQueryHandler handler,
        CancellationToken ct
    )
    {
        var accSummary = await handler.Handle(
            new(accountReferenceId),
            ct
        );

        return accSummary is null ?
            Results.NotFound() :
            Results.Ok(accSummary);
    }
}