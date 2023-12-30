namespace Verico.Api.Endpoints;

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
            .Produces(StatusCodes.Status400BadRequest);

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
}