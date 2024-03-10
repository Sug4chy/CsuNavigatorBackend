namespace CsuNavigatorBackend.Services.Requests.Edges;

public record CreateEdgeRequest
{
    public required Guid Point1Id { get; init; }
    public required Guid Point2Id { get; init; }
}