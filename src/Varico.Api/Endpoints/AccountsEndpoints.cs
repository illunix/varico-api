namespace Varico.Api.Endpoints;

internal static class AccountsEndpoints
{
    public static RouteGroupBuilder MapAccountsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("accounts");

        group.MapGet(
            "/",
            GetAccounts
        )
            .WithName("Get accounts")
            .Produces<IEnumerable<AccountDto>>()
            .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest);

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

    private static async Task<IResult> GetAccounts(
        IMediator mediator,
        CancellationToken ct
    )
        => Results.Ok(await mediator.Send(
            new GetAccountsQuery(),
            ct
        ));

    private static async Task<IResult> CreateTransaction(
        string accountReferenceId,
        CreateTransactionCommand cmd,
        IMediator mediator,
        CancellationToken ct
    )
    {
        await mediator.Send(
            cmd with { AccountReferenceId = accountReferenceId },
            ct
        );

        return Results.NoContent();
    }

    private static async Task<IResult> GetAccountSummary(
        string accountReferenceId,
        IMediator mediator,
        CancellationToken ct
    )
    {
        var accSummary = await mediator.Send(
            new GetAccountSummaryQuery(accountReferenceId),
            ct
        );

        return accSummary is null ?
            Results.NotFound() :
            Results.Ok(accSummary);
    }
}