using CsuNavigatorBackend.ApplicationServices;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Services.Services;

public class OrganizationService(NavigatorDbContext context) : IOrganizationService
{
    public Task<Organization?> GetOrganizationByNameAsync(string name, CancellationToken ct = default)
        => context.Organizations.FirstOrDefaultAsync(o => o.Name == name
                                                          && o.DeletedAt == null, ct);
}