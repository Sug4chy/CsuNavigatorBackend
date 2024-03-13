using CsuNavigatorBackend.Api.Exceptions;
using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Points;
using CsuNavigatorBackend.Services.Validators.Points;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Api.Controllers;

[ApiController]
[Route("/api/maps/{mapId:guid}/[controller]")]
public class PointsController(
    IMapService mapService,
    IPointService pointService
) : ControllerBase
{
    [HttpPost]
    public async Task CreatePoint(
        [FromRoute] Guid mapId,
        [FromBody] CreatePointRequest request,
        [FromServices] CreatePointRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var map = await mapService.GetMapOnlyWithPointsByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        map!.PointsWithoutEdges ??= new List<MarkerPoint>();
        await pointService.CreateMarkerPointAsync(request.Point, map, ct);
    }

    [HttpPut("{pointId:guid}")]
    public async Task UpdatePoint(
        [FromRoute] Guid mapId,
        [FromRoute] Guid pointId,
        [FromBody] UpdatePointRequest request,
        [FromServices] UpdatePointRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        if (!await mapService.CheckIfMapExistAsync(mapId, ct))
        {
            throw new NotFoundException
            {
                Error = MapErrors.NoSuchMapWithId(mapId)
            };
        }

        var point = await pointService.GetMarkerPointByIdAsync(pointId, ct);
        NotFoundException.ThrowIfNull(point, MarkerPointErrors.NoSuchPointWithId(pointId));

        await pointService.UpdateMarkerPointAsync(point!, request.UpdatedPoint, ct);
    }
}