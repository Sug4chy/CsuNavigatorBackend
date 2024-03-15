namespace CsuNavigatorBackend.Api.Responses.Auth;

public record RegisterResponse
{
    public required string Jwt { get; init; }
}