namespace CsuNavigatorBackend.Api.Exceptions;

public class ConflictException : ExceptionBase
{
    public override int StatusCode => StatusCodes.Status409Conflict;
}