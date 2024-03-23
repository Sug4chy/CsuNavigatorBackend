using System.Security.Claims;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Domain.Entities;
using CsuNavigatorBackend.Domain.Errors;
using CsuNavigatorBackend.Web.Exceptions;

namespace CsuNavigatorBackend.Web.Auth;

public class CurrentUserAccessor(
    IUserService userService,
    IHttpContextAccessor httpContextAccessor) : ICurrentUserAccessor
{
    private readonly HttpContext _httpContext = httpContextAccessor.HttpContext!;
    
    public async Task<User> GetCurrentUserAsync(CancellationToken ct = default)
    {
        string userId = _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                        ?? throw new UnauthorizedException
                        {
                            Error = AuthErrors.JwtDoesNotIncludeClaim(ClaimTypes.NameIdentifier)
                        };
        if (!Guid.TryParse(userId, out var id))
        {
            throw new UnauthorizedException
            {
                Error = AuthErrors.InvalidClaim(ClaimTypes.NameIdentifier)
            };
        }

        var currentUser = await userService.GetUserByIdAsync(id, ct);
        NotFoundException.ThrowIfNull(currentUser, UserErrors.NoSuchUserWithId(id));

        return currentUser!;
    }
}