using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Services;

public class EdgeService(NavigatorDbContext context) : IEdgeService
{
    public async Task CreateEdgeAsync(Guid point1Id, Guid point2Id, Map map, CancellationToken ct = default)
    {
        var edge = new Edge
        {
            Point1Id = point1Id,
            Point2Id = point2Id
        };
        map.Edges!.Add(edge);
        var point1 = map.PointsWithoutEdges!.FirstOrDefault(mp => mp.Id == point1Id);
        if (point1 is not null)
        {
            map.PointsWithoutEdges!.Remove(point1);
        }
        
        var point2 = map.PointsWithoutEdges!.FirstOrDefault(mp => mp.Id == point2Id);
        if (point2 is not null)
        {
            map.PointsWithoutEdges!.Remove(point2);
        }

        await context.SaveChangesAsync(ct);
    }
}