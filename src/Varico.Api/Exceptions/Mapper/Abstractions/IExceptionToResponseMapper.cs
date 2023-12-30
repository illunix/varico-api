namespace Varico.Api.Exceptions.Mapper.Abstractions;

public interface IExceptionToResponseMapper
{
    ExceptionResponse Map(Exception ex);
}