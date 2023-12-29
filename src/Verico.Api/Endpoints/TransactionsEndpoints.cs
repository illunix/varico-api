namespace Verico.Api.Endpoints;

internal static class TransactionsEndpoints
{
    public static RouteGroupBuilder MapTransactionsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transactions");

        group.MapPost(
            "/accounts/{accountReferenceId}/transactions",
            CreateTransaction
        )
            .WithName("Create transaction")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);

        group.MapPatch(
            "/{transactionReferenceId}",
            UpdateTransactionCategory
        )
            .WithName("Change transaction category")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status400BadRequest);

        group.MapGet(
            "/",
            GetTransactions
        )
            .WithName("Get transactions")
            .Produces<IEnumerable<TransactionDto>>()
            .Produces(StatusCodes.Status400BadRequest);

        group.WithTags("Transactions");

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

    private static async Task<IResult> UpdateTransactionCategory(
        ChangeTransactionCategoryCommand cmd,
        ChangeTransactionCategoryCommandHandler handler,
        CancellationToken ct
    )
    {
        await handler.Handle(
            cmd,
            ct
        );

        return Results.NoContent();
    }

    private static async Task<IResult> GetTransactions(
        GetTransactionsQueryHandler handler,
        CancellationToken ct
    )
    {
        var transactions = await handler.Handle(
            new GetTransactionsQuery(),
            ct
        );

        return Results.Ok(transactions);
    }
}