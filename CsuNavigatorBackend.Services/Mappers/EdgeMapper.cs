using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Mappers;

public class EdgeMapper(IMapper<MarkerPoint, PointDto> pointMapper) : IMapper<Edge, EdgeDto>
{
    public EdgeDto Map(Edge from)
        => new()
        {
            Id = from.Id,
            Point1 = pointMapper.Map(from.Point1!),
            Point2 = pointMapper.Map(from.Point2!)
        };

}