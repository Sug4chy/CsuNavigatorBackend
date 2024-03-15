using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IProfileService
{
    Task CreateProfileAsync(ProfileDto dto, User user, CancellationToken ct = default);
}