namespace CsuNavigatorBackend.Api.Dto
{
    public record EdgeDto
    {
        public required PointDto Point1 { get; init; }
        public required PointDto Point2 { get; init; }

    }
}
