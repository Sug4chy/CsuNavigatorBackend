using CsuNavigatorBackend.Api.Dto;
using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Api.Services;

public class MapService(NavigatorDbContext context) : IMapService
{
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
}