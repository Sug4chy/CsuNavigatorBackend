using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Services;

public class PointService(NavigatorDbContext context) : IPointService
{
    public async Task CreateMarkerPointAsync(PointDto dto, Map map, CancellationToken ct = default)
    {
        var point = new MarkerPoint
        {
            X = dto.X,
            Y = dto.Y,
            Description = dto.Description,
            MarkerType = Enum.Parse<MarkerType>(dto.Type)
        };
        map.PointsWithoutEdges!.Add(point);
        await context.SaveChangesAsync(ct);
    }
}