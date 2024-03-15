using CsuNavigatorBackend.ApplicationServices.Services;
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

    public async Task DeleteEdgeAsync(Edge edge, Map map, CancellationToken ct = default)
    {
        var point1 = edge.Point1!;
        point1.EdgesAsPoint1!.Remove(edge);
        if (point1.EdgesAsPoint1!.Count == 0)
        {
            map.PointsWithoutEdges!.Add(point1);
        }

        var point2 = edge.Point2!;
        point2.EdgesAsPoint2!.Remove(edge);
        if (point2.EdgesAsPoint2!.Count == 0)
        {
            map.PointsWithoutEdges!.Add(point2);
        }

        map.Edges!.Remove(edge);
        await context.SaveChangesAsync(ct);
    }
}