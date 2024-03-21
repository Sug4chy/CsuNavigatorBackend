using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Requests.Auth;

public record LoginRequest
{
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required Role LoginSource { get; init; }
}