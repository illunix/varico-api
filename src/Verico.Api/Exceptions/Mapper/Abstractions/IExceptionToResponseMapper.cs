namespace Verico.Api.Exceptions.Mapper.Abstractions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception ex);
}