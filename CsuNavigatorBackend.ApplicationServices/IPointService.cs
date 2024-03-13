using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IPointService
{
    Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid pointId, CancellationToken ct = default);
    Task CreateMarkerPointAsync(PointDto dto, Map map, CancellationToken ct = default);
    Task UpdateMarkerPointAsync(MarkerPoint point, PointDto dto, CancellationToken ct = default);
    Task DeleteMarkerPointAsync(MarkerPoint point, CancellationToken ct = default);
}