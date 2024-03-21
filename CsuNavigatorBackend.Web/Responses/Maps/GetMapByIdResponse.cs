using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Web.Responses.Maps;

public record GetMapByIdResponse
{
    public required MapDto Map { get; init; }
}