using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Services.Requests.Points;

public record UpdatePointRequest
{
    public required PointDto UpdatedPoint { get; init; }
}