using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IPointService
{
    Task CreateMarkerPointAsync(PointDto dto, Map map, CancellationToken ct = default);
}