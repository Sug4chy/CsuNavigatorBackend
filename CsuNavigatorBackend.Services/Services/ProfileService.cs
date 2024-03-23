using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.Services.Services;

public class ProfileService(NavigatorDbContext context) : IProfileService
{
    public async Task CreateProfileAsync(ProfileDto dto, User user, CancellationToken ct = default)
    {
        var profile = new Profile
        {
            Name = dto.Name,
            Surname = dto.Surname,
            Patronymic = dto.Patronymic,
            User = user
        };
        user.Profile = profile;
        await context.Profiles.AddAsync(profile, ct);
    }
}