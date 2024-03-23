using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Services;

public class AuthService(
    IProfileService profileService,
    ITokenService tokenService,
    IPasswordHasher passwordHasher,
    NavigatorDbContext context) : IAuthService
{
    public async Task<string> RegisterMobileUserAsync(User user, ProfileDto profileDto,
        CancellationToken ct = default)
    {
        await context.Users.AddAsync(user, ct);
        await profileService.CreateProfileAsync(profileDto, user, ct);
        await context.SaveChangesAsync(ct);

        return tokenService.CreateJwtForUser(user);
    }

    public string LoginUser(User user, string password)
        => !passwordHasher.VerifyPassword(password, user.Password)
            ? string.Empty
            : tokenService.CreateJwtForUser(user);
}