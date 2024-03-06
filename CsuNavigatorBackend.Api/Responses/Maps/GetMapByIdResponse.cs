using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Api.Responses.Maps;

public record GetMapByIdResponse
{
    public required MapDto Map { get; init; }
}