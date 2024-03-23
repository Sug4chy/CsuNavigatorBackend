using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Edges;
using CsuNavigatorBackend.Services.Validators.Edges;
using CsuNavigatorBackend.Web.Auth;
using CsuNavigatorBackend.Web.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Web.Controllers;

[ApiController]
[Route("/api/maps/{mapId:guid}/[controller]")]
public class EdgesController(
    IMapService mapService,
    IEdgeService edgeService,
    IPointService pointService,
    ICurrentUserAccessor userAccessor,
    IUserService userService) : ControllerBase
{
    [Authorize(Policy = Policies.OnlyDesktopUsers)]
    [HttpPost]
    public async Task CreateEdge(
        [FromRoute] Guid mapId,
        [FromBody] CreateEdgeRequest request,
        [FromServices] CreateEdgeRequestValidator validator,
        CancellationToken ct = default)
    {
        var currentUser = await userAccessor.GetCurrentUserAsync(ct);
        
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var map = await mapService.GetFullMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        if (map!.Edges.Any(e => (e.Point1Id == request.Point1Id && e.Point2Id == request.Point2Id) ||
                                (e.Point1Id == request.Point2Id && e.Point2Id == request.Point1Id)))
        {
            throw new ConflictException
            {
                Error = EdgeErrors.EdgeWithSuchPointsAlreadyExists(request.Point1Id, request.Point2Id)
            };
        }
        if (!await userService.CheckIfUserIsOrganizationAccountAsync(currentUser, map!.OrganizationId, ct))
        {
            throw new ForbiddenException
            {
                Error = AuthErrors.UserIsNotCreatorOfMap(mapId)
            };
        }

        var point1 = await pointService.GetMarkerPointByIdAsync(request.Point1Id, ct);
        NotFoundException.ThrowIfNull(point1, MarkerPointErrors.NoSuchPointWithId(request.Point1Id));
        
        var point2 = await pointService.GetMarkerPointByIdAsync(request.Point2Id, ct);
        NotFoundException.ThrowIfNull(point2, MarkerPointErrors.NoSuchPointWithId(request.Point2Id));

        map.Edges ??= new List<Edge>();
        await edgeService.CreateEdgeAsync(request.Point1Id, request.Point2Id, map, ct);
    }

    [Authorize(Policy = Policies.OnlyDesktopUsers)]
    [HttpDelete("{edgeId:guid}")]
    public async Task DeleteEdge(
        [FromRoute] Guid mapId,
        [FromRoute] Guid edgeId,
        CancellationToken ct = default)
    {
        var currentUser = await userAccessor.GetCurrentUserAsync(ct);
        
        var map = await mapService.GetFullMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));
        if (!await userService.CheckIfUserIsOrganizationAccountAsync(currentUser, map!.OrganizationId, ct))
        {
            throw new ForbiddenException
            {
                Error = AuthErrors.UserIsNotCreatorOfMap(mapId)
            };
        }

        var edge = map.Edges?.FirstOrDefault(e => e.Id == edgeId);
        NotFoundException.ThrowIfNull(edge, EdgeErrors.NoSuchEdgeWithId(edgeId));

        await edgeService.DeleteEdgeAsync(edge!, map, ct);
    }
}