using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Services.Services;

public class MapService(NavigatorDbContext context) : IMapService
{
    public Task<bool> CheckIfMapExistAsync(Guid mapId, CancellationToken ct = default)
        => context.Maps.AnyAsync(m => m.Id == mapId, ct);

    public Task<Map?> GetFullMapByIdAsync(Guid mapId, CancellationToken ct = default)
        => context.Maps
            .Include(m => m.Edges)!
            .ThenInclude(e => e.Point1)
            .Include(m => m.Edges)!
            .ThenInclude(e => e.Point2)
            .Include(m => m.PointsWithoutEdges)
            .FirstOrDefaultAsync(m => m.Id == mapId, ct);

    public Task<Map?> GetMapOnlyWithPointsByIdAsync(Guid mapId, CancellationToken ct = default)
        => context.Maps
            .Include(m => m.PointsWithoutEdges)
            .FirstOrDefaultAsync(m => m.Id == mapId, ct);
    
    public Task<Map?> GetMapByIdAsync(Guid mapId, CancellationToken ct = default) 
        => context.Maps
            .FirstOrDefaultAsync(m => m.Id == mapId, ct);
    
    public async Task CreateMapAsync(MapDto dto, Organization organization, CancellationToken ct = default)
    {
        var edges = dto.Edges.Select(edgeDto => new Edge
        {
            Point1 = new MarkerPoint
            {
                Description = edgeDto.Point1.Description,
                X = edgeDto.Point1.X,
                Y = edgeDto.Point1.Y,
                MarkerType = Enum.Parse<MarkerType>(edgeDto.Point1.Type)
            },
            Point2 = new MarkerPoint
            {
                Description = edgeDto.Point2.Description,
                X = edgeDto.Point2.X,
                Y = edgeDto.Point2.Y,
                MarkerType = Enum.Parse<MarkerType>(edgeDto.Point2.Type)
            }
        }).ToList();
        var map = new Map
        {
            Description = dto.Description,
            Title = dto.Title,
            Edges = edges,
            Organization = organization,
            OrganizationId = organization.Id
        };
        await context.Maps.AddAsync(map, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateMapAsync(Map map, MapDto dto, CancellationToken ct = default)
    {
        map.Title = dto.Title;
        map.Description = dto.Description;

        context.Maps.Update(map);
        await context.SaveChangesAsync(ct);
    }
}