using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Mappers;

public class PointMapper : IMapper<MarkerPoint, PointDto>
{
    public PointDto Map(MarkerPoint from)
        => new()
        {
            Id = from.Id,
            X = from.X,
            Y = from.Y,
            Description = from.Description,
            Type = from.MarkerType.ToString()
        };

}