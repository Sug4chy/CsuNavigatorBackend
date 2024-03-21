namespace CsuNavigatorBackend.Web.Responses.Auth;

public record MobileRegisterResponse
{
    public required string Jwt { get; init; }
}