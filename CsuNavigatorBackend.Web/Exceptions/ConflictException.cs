namespace CsuNavigatorBackend.Web.Exceptions;

public class ConflictException : ExceptionBase
{
    public override int StatusCode => StatusCodes.Status409Conflict;
}