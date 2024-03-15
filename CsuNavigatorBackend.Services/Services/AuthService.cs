using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Database.Context;

namespace CsuNavigatorBackend.Services.Services;

public class AuthService(
    IMapper<MobileRegisterDto, UserDto> mobileUserDtoMapper,
    IMapper<MobileRegisterDto, ProfileDto> mobileProfileDtoMapper,
    IUserService userService,
    IProfileService profileService,
    ITokenService tokenService,
    NavigatorDbContext context) : IAuthService
{
    public async Task<string> RegisterMobileUserAsync(MobileRegisterDto dto, CancellationToken ct = default)
    {
        var user = await userService.CreateUserAsync(mobileUserDtoMapper.Map(dto), ct);
        if (user is null)
        {
            return "";
        }
        
        await profileService
            .CreateProfileAsync(mobileProfileDtoMapper.Map(dto), user, ct);
        await context.SaveChangesAsync(ct);

        return tokenService.CreateJwtForUser(user);
    }
}