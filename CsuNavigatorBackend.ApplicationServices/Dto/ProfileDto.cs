namespace CsuNavigatorBackend.ApplicationServices.Dto;

public record ProfileDto
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public string? Patronymic { get; set; }
}