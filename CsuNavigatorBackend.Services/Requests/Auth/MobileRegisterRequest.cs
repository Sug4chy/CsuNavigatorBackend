namespace CsuNavigatorBackend.Services.Requests.Auth;

public record MobileRegisterRequest
{
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public string? Patronymic { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}