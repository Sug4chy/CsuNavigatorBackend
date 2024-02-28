using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices;

public interface IOrganizationService
{
    Task<Organization?> GetOrganizationByNameAsync(string name, CancellationToken ct = default);
}