using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.Domain.Entities;

namespace CsuNavigatorBackend.ApplicationServices.Services;

public interface IUserService
{
    Task<User?> CreateUserAsync(UserDto dto, CancellationToken ct = default);
    Task<User?> GetUserByUsernameAndRoleAsync(string username, Role role, CancellationToken ct = default);
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken ct = default);
    bool CheckIfUserIsOrganizationAccount(User user, string orgName);
    Task<bool> CheckIfUserIsOrganizationAccountAsync(User user, Guid orgId, CancellationToken ct = default);
}