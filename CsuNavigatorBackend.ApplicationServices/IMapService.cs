using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IMapService
{
    Task CreateMapAsync(MapDto dto, Organization organization, CancellationToken ct = default);
    Task<Map?> GetMapByIdAsync(Guid mapId, CancellationToken ct = default);
}