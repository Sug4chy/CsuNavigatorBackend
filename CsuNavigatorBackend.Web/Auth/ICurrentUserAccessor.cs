using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Web.Auth;

public interface ICurrentUserAccessor
{
    Task<User> GetCurrentUserAsync(CancellationToken ct = default);
}