namespace CsuNavigatorBackend.Web.Responses.Auth;

public record LoginResponse
{
    public required string Jwt { get; init; }
}