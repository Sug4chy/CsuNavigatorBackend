namespace CsuNavigatorBackend.Services.Requests.Maps;

public record UpdateMapRequest
{
    public required string NewTitle { get; init; }
    public string? NewDescription { get; init; }
}