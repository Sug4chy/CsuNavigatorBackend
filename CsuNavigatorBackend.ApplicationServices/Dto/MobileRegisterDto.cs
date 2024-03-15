namespace CsuNavigatorBackend.ApplicationServices.Dto;

public record MobileRegisterDto
{
    public required string Name { get; init; }
    public required string Surname { get; init; }
    public string? Patronymic { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
}