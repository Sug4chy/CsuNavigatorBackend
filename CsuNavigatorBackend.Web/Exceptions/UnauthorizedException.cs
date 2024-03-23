namespace CsuNavigatorBackend.Web.Exceptions;

public class UnauthorizedException : ExceptionBase
{
    public override int StatusCode => StatusCodes.Status401Unauthorized;
}