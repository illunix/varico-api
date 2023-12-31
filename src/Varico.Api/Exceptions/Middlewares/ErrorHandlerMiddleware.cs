namespace Varico.Api.Exceptions.Middlewares;

internal sealed class ErrorHandlerMiddleware(
    IExceptionToResponseMapper mapper,
    ILogger<ErrorHandlerMiddleware> logger
) : IMiddleware
{
    public async Task InvokeAsync(
        HttpContext ctx,
        RequestDelegate next
    )
    {
        try
        {
            await next(ctx);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                ex.Message
            );

            await HandleError(
                ctx,
                ex
            );
        }
    }

    private async Task HandleError(
        HttpContext ctx,
        Exception ex
    )
    {
        var errRes = mapper.Map(ex);
        ctx.Response.StatusCode = (int)(errRes?.Code ?? HttpStatusCode.InternalServerError);
        var res = errRes?.Response;
        if (res is null)
            return;

        await ctx.Response.WriteAsJsonAsync(res);
    }
}