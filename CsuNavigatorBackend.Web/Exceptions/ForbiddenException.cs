namespace CsuNavigatorBackend.Web.Exceptions;

public class ForbiddenException : ExceptionBase
{
    public override int StatusCode => StatusCodes.Status403Forbidden;
}