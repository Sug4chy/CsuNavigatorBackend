using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IAuthService
{
    Task<string> RegisterMobileUserAsync(User user, ProfileDto profileDto, CancellationToken ct = default);
    string LoginUser(User user, string password);
}