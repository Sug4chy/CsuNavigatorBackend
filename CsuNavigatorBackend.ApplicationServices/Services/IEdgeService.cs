using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IEdgeService
{
    Task CreateEdgeAsync(Guid point1Id, Guid point2Id, Map map, CancellationToken ct = default);
    Task DeleteEdgeAsync(Edge edge, Map map, CancellationToken ct = default);
}