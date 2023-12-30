namespace Verico.Api.Endpoints;

internal static class TransactionsEndpoints
{
    public static RouteGroupBuilder MapTransactionsEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("transactions");

        group.MapPatch(
            "/{transactionReferenceId}/category",
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

    private static async Task<IResult> UpdateTransactionCategory(
        UpdateTransactionCategoryCommand cmd,
        UpdateTransactionCategoryCommandHandler handler,
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
        Guid? accountReferenceId,
        string? category,
        GetTransactionsQueryHandler handler,
        CancellationToken ct
    )
    {
        var transactions = await handler.Handle(
            new GetTransactionsQuery(
                accountReferenceId,
                category
            ),
            ct
        );

        return Results.Ok(transactions);
    }
}