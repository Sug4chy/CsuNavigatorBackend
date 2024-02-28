using CsuNavigatorBackend.Api.Dto;

namespace CsuNavigatorBackend.Api.Requests.Maps
{
    public record CreateMapRequest
    {
        public required MapDto Map { get; init; }
        public required string OrganizationName { get; init; }
    }
}
