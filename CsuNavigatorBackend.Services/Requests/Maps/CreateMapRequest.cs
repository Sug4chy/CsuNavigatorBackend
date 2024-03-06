using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.Services.Requests.Maps
{
    public record CreateMapRequest
    {
        public required MapDto Map { get; init; }
        public required string OrganizationName { get; init; }
    }
}
