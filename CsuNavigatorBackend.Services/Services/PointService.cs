using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Services.Services;

public class PointService(
    NavigatorDbContext context,
    IEdgeService edgeService) : IPointService
{
    public Task<MarkerPoint?> GetMarkerPointByIdAsync(Guid pointId, CancellationToken ct = default)
        => context.MarkerPoints
            .Include(mp => mp.EdgesAsPoint1)!
            .ThenInclude(e => e.Point2)
            .Include(mp => mp.EdgesAsPoint2)!
            .ThenInclude(e => e.Point1)
            .FirstOrDefaultAsync(mp => mp.Id == pointId, ct);

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

    public async Task UpdateMarkerPointAsync(MarkerPoint point, PointDto dto, CancellationToken ct = default)
    {
        point.X = dto.X;
        point.Y = dto.Y;
        point.Description = dto.Description;
        point.MarkerType = Enum.Parse<MarkerType>(dto.Type);

        context.MarkerPoints.Update(point);
        await context.SaveChangesAsync(ct);
    }

    public async Task DeleteMarkerPointAsync(MarkerPoint point, Map map, CancellationToken ct = default)
    {
        foreach (var edge in point.EdgesAsPoint1!)
        {
            await edgeService.DeleteEdgeAsync(edge, map, ct);
        }

        foreach (var edge in point.EdgesAsPoint2!)
        {
            await edgeService.DeleteEdgeAsync(edge, map, ct);
        }
        
        context.MarkerPoints.Remove(point);
        await context.SaveChangesAsync(ct);
    }
}