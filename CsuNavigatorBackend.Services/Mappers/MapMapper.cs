using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Mappers;

public class MapMapper(IMapper<Edge, EdgeDto> edgeMapper,
    IMapper<MarkerPoint, PointDto> pointMapper) : IMapper<Map, MapDto>
{
    public MapDto Map(Map from)
        => new()
        {
            Id = from.Id,
            Title = from.Title,
            Description = from.Description,
            Edges = from.Edges!.Select(edgeMapper.Map).ToArray(),
            PointsWithoutEdges = from.PointsWithoutEdges!.Select(pointMapper.Map).ToArray() 
        };

}