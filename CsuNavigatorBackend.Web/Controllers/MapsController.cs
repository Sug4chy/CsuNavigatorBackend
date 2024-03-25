using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Maps;
using CsuNavigatorBackend.Services.Validators.Maps;
using CsuNavigatorBackend.Web.Auth;
using CsuNavigatorBackend.Web.Exceptions;
using CsuNavigatorBackend.Web.Responses.Maps;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MapsController(
    IMapService mapService,
    IOrganizationService organizationService,
    ICurrentUserAccessor userAccessor,
    IUserService userService) : ControllerBase
{
    [Authorize(Policy = Policies.OnlyDesktopUsers)]
    [HttpPost]
    public async Task CreateMap(
        [FromBody] CreateMapRequest request,
        [FromServices] CreateMapRequestValidator validator,
        CancellationToken ct = default)
    {
        var currentUser = await userAccessor.GetCurrentUserAsync(ct);

        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var organization = await organizationService
            .GetOrganizationByNameAsync(request.OrganizationName, ct);
        NotFoundException.ThrowIfNull(organization,
            OrganizationErrors.NoSuchOrganizationWithName(request.OrganizationName));

        if (!await mapService.CheckIfMapExistByTitleAsync(request.Map.Title, ct))
        {
            throw new ConflictException
            {
                Error = MapErrors.MapWithSuchNameAlreadyExists(request.Map.Title)
            };
        }

        if (!userService.CheckIfUserIsOrganizationAccount(currentUser, organization!.Name))
        {
            throw new ForbiddenException
            {
                Error = AuthErrors.UserIsNotOrganizationAccount(organization.Name)
            };
        }

        await mapService.CreateMapAsync(request.Map, organization, ct);
    }

    [Authorize]
    [HttpGet("{mapId:guid}")]
    public async Task<GetMapByIdResponse> GetMapById(
        [FromRoute] Guid mapId,
        [FromServices] IMapper<Map, MapDto> mapMapper,
        CancellationToken ct = default)
    {
        var map = await mapService.GetFullMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        return new GetMapByIdResponse
        {
            Map = mapMapper.Map(map!)
        };
    }

    [Authorize(Policy = Policies.OnlyDesktopUsers)]
    [HttpPut("{mapId:guid}")]
    public async Task UpdateMap(
        [FromRoute] Guid mapId,
        [FromBody] UpdateMapRequest request,
        [FromServices] UpdateMapRequestValidator validator,
        CancellationToken ct = default)
    {
        var currentUser = await userAccessor.GetCurrentUserAsync(ct);

        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var map = await mapService.GetMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));
        if (!await userService.CheckIfUserIsOrganizationAccountAsync(currentUser, map!.OrganizationId, ct))
        {
            throw new ForbiddenException
            {
                Error = AuthErrors.UserIsNotCreatorOfMap(mapId)
            };
        }

        await mapService.UpdateMapAsync(map, request.NewTitle, request.NewDescription, ct);
    }

    [Authorize(Policy = Policies.OnlyDesktopUsers)]
    [HttpDelete("{mapId:guid}")]
    public async Task DeleteMap(
        [FromRoute] Guid mapId,
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

        await mapService.DeleteMapAsync(map, ct);
    }
}