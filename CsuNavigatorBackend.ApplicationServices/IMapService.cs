﻿using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IMapService
{
    Task<bool> CheckIfMapExistAsync(Guid mapId, CancellationToken ct = default);
    Task<Map?> GetFullMapByIdAsync(Guid mapId, CancellationToken ct = default);
    Task<Map?> GetMapOnlyWithPointsByIdAsync(Guid mapId, CancellationToken ct = default);
    Task CreateMapAsync(MapDto dto, Organization organization, CancellationToken ct = default);
}