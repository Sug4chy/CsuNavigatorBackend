﻿using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Services.Requests.Maps;
using CsuNavigatorBackend.Services.Validators.Maps;
using CsuNavigatorBackend.Web.Exceptions;
using CsuNavigatorBackend.Web.Responses.Maps;
using Microsoft.AspNetCore.Mvc;

namespace CsuNavigatorBackend.Web.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MapsController(
    IMapService mapService,
    IOrganizationService organizationService) : ControllerBase
{
    [HttpPost]
    public async Task CreateMap(
        [FromBody] CreateMapRequest request, 
        [FromServices] CreateMapRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var organization = await organizationService
            .GetOrganizationByNameAsync(request.OrganizationName, ct);
        NotFoundException.ThrowIfNull(organization, 
            OrganizationErrors.NoSuchOrganizationWithName(request.OrganizationName));

        await mapService.CreateMapAsync(request.Map, organization!, ct);
    }

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

    [HttpPut("{mapId:guid}")]
    public async Task UpdateMap(
        [FromRoute] Guid mapId,
        [FromBody] UpdateMapRequest request,
        [FromServices] UpdateMapRequestValidator validator,
        CancellationToken ct = default)
    {
        var validationResult = await validator.ValidateAsync(request, ct);
        BadRequestException.ThrowByValidationResult(validationResult);

        var map = await mapService.GetMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        await mapService.UpdateMapAsync(map!, request.UpdatedMap, ct);
    }

    [HttpDelete("{mapId:guid}")]
    public async Task DeleteMap(
        [FromRoute] Guid mapId,
        CancellationToken ct = default)
    {
        var map = await mapService.GetFullMapByIdAsync(mapId, ct);
        NotFoundException.ThrowIfNull(map, MapErrors.NoSuchMapWithId(mapId));

        await mapService.DeleteMapAsync(map!, ct);
    }
}