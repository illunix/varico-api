﻿namespace Varico.Api.Endpoints;

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
            .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest);

        group.MapGet(
            "/",
            GetTransactions
        )
            .WithName("Get transactions")
            .Produces<IEnumerable<TransactionDto>>()
            .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest);

        group.MapDelete(
           "/{transactionReferenceId}",
           RemoveTransaction
        )
           .WithName("Remove transaction")
           .Produces(StatusCodes.Status204NoContent)
           .Produces<ExceptionResponse>(StatusCodes.Status400BadRequest);

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
        string? accountReferenceId,
        string? category,
        GetTransactionsQueryHandler handler,
        CancellationToken ct
    )
    {
        var transactions = await handler.Handle(
            new(
                accountReferenceId,
                category
            ),
            ct
        );

        return Results.Ok(transactions);
    }

    private static async Task<IResult> RemoveTransaction(
        string accountReferenceId,
        RemoveTransactionCommandHandler handler,
        CancellationToken ct
    )
    {
        await handler.Handle(
            new(accountReferenceId),
            ct
        );

        return Results.NoContent();
    }
}