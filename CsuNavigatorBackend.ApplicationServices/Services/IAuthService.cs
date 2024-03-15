using CsuNavigatorBackend.ApplicationServices.Dto;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IAuthService
{
    Task<string> RegisterMobileUserAsync(MobileRegisterDto dto, CancellationToken ct = default);
}