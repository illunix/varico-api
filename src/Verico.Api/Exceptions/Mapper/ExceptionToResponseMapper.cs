namespace Verico.Api.Exceptions.Mapper;

internal sealed class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private readonly ConcurrentDictionary<Type, string> _codes = new();

    public ExceptionResponse Map(Exception ex)
        => ex switch
    {
        ExceptionBase exBase => new ExceptionResponse(new ErrorsResponse(
            new Error(
                GetErrorCode(ex),
                ex.Message
            )),
            HttpStatusCode.BadRequest
        ),
        ArgumentException _ => new(new ErrorsResponse(
            new Error(
                GetErrorCode(ex),
                ex.Message
            )),
            HttpStatusCode.BadRequest
        ),
        _ => new(new ErrorsResponse(
            new Error(
                "error",
                "There was an error."
            )),
            HttpStatusCode.InternalServerError
        )
    };

    private string GetErrorCode(object ex)
    {
        var type = ex.GetType();

        return _codes.GetOrAdd(
            type,
            type.Name
                .Underscore()
                .Replace(
                    "_exception",
                    string.Empty
                )
        );
    }
}