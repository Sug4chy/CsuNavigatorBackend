using CsuNavigatorBackend.Api.Exceptions;
using CsuNavigatorBackend.Api.Responses.Edges;
using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Edges;
using CsuNavigatorBackend.Services.Validators.Edges;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Api.Controllers;

[ApiController]
[Route("/api/maps/{mapId:guid}/[controller]")]
public class EdgesController(
    IMapService mapService,
    IEdgeService edgeService) : ControllerBase
{
    [HttpPost]
    public async Task<CreateEdgeResponse> CreateEdge(
        [FromRoute] Guid mapId,
        [FromBody] CreateEdgeRequest request,
        [FromServices] CreateEdgeRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var map = await mapService.GetFullMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        map!.Edges ??= new List<Edge>();
        await edgeService.CreateEdgeAsync(request.Point1Id, request.Point2Id, map, ct);

        return new CreateEdgeResponse();
    }
}