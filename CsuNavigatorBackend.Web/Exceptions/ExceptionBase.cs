using CsuNavigatorBackend.Domain.Errors;

namespace CsuNavigatorBackend.Web.Exceptions;

public abstract class ExceptionBase : Exception
{
    public abstract int StatusCode { get; }
    public Error Error { get; init; } = Error.None;
}