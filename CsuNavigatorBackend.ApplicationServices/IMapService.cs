using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IMapService
{
    Task<bool> CheckIfMapExistAsync(Guid mapId, CancellationToken ct = default);
    Task<Map?> GetFullMapByIdAsync(Guid mapId, CancellationToken ct = default);
    Task<Map?> GetMapOnlyWithPointsByIdAsync(Guid mapId, CancellationToken ct = default);
    Task<Map?> GetMapByIdAsync(Guid mapId, CancellationToken ct = default);
    Task CreateMapAsync(MapDto dto, Organization organization, CancellationToken ct = default);
    Task UpdateMapAsync(Map map, MapDto dto, CancellationToken ct = default);
    Task DeleteMapAsync(Map map, CancellationToken ct = default);
}