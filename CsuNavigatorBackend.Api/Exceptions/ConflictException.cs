namespace CsuNavigatorBackend.Api.Exceptions;

public class ConflictException : ExceptionBase
{
    public override int StatusCode { get; } = StatusCodes.Status409Conflict;
}