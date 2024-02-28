using CsuNavigatorBackend.Api.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IMapService
{
    Task CreateMapAsync(MapDto dto, Organization organization, CancellationToken ct = default);
}