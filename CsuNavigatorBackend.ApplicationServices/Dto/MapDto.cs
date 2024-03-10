namespace CsuNavigatorBackend.ApplicationServices.Dto
{
    public record MapDto
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public required EdgeDto[] Edges { get; init; }
        public required PointDto[] PointsWithoutEdges { get; init; }
    }
}
