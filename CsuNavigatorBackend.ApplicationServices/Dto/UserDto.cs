using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Dto;

public record UserDto
{
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required Role Role { get; init; }
}