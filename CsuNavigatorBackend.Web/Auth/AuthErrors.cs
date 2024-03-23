using CsuNavigatorBackend.Domain.Errors;

namespace CsuNavigatorBackend.Web.Auth;

public static class AuthErrors
{
    public static Error InvalidPassword 
        => new(nameof(InvalidPassword),
        "Password is invalid");

    public static Error JwtDoesNotIncludeClaim(string claimType)
        => new(nameof(JwtDoesNotIncludeClaim),
            $"JWT doesn't include claim with type {claimType}");

    public static Error InvalidClaim(string claimType)
        => new(nameof(InvalidClaim),
            $"Claim with type {claimType} is invalid in JWT");

    public static Error UserIsNotCreatorOfMap(Guid mapId)
        => new(nameof(UserIsNotCreatorOfMap),
            $"Current user isn't creator of map with id {mapId}");

    public static Error UserIsNotOrganizationAccount(string orgName)
        => new(nameof(UserIsNotOrganizationAccount),
            $"Current user is not an account of organization {orgName}");
}