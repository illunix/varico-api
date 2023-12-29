namespace Verico.Api.Exceptions.Models;

public sealed record ExceptionResponse(
    object Response,
    HttpStatusCode Code
);