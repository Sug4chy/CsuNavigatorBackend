using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IUserService
{
    Task<User?> CreateUserAsync(UserDto dto, CancellationToken ct = default);
}