using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Services.Requests.Maps;

public record UpdateMapRequest
{
    public required MapDto UpdatedMap { get; init; }
}