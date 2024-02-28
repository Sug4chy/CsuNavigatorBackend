namespace CsuNavigatorBackend.Api.Dto
{
    public record PointDto
    {
        public required double X { get; init; }
        public required double Y { get; init; }
        public string? Description { get; init; }

        public required string Type { get; init; }
    }
}
