namespace CsuNavigatorBackend.ApplicationServices.Dto
{
    public record MapDto
    {
        public required string Title { get; init; }
        public string? Description { get; init; }
        public EdgeDto[] Edges { get; init; } = Array.Empty<EdgeDto>();
    }
}
