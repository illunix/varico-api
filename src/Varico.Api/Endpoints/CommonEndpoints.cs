namespace Varico.Api.Endpoints;

internal static class CommonEndpoints
{
    public static RouteGroupBuilder MapCommonEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("");

        group.MapGet(
            "/transaction-categories",
            GetTransactionCategories
        )
            .WithName("Get transaction categories")
            .Produces<IEnumerable<string>>();

        group.WithTags("");

        return group;
    }

    private static async Task<IResult> GetTransactionCategories(
        IMediator mediator,
        CancellationToken ct
    )
        => Results.Ok(await mediator.Send(
            new GetTransactionCategoriesQuery(),
            ct
        ));
}