using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Services.Requests.Points;

public record CreatePointRequest
{
    public required PointDto Point { get; init; }
}