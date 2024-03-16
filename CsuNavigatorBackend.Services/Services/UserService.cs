using CsuNavigatorBackend.ApplicationServices.Dto;
using CsuNavigatorBackend.ApplicationServices.Services;
using CsuNavigatorBackend.Database.Context;
using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Services.Services;

public class UserService(
    NavigatorDbContext context,
    IPasswordHasher hasher) : IUserService
{
    public async Task<User?> CreateUserAsync(UserDto dto, CancellationToken ct = default)
    {
        if (await context.Users.AnyAsync(u => u.Username.Equals(dto.Username), ct))
        {
            return null;
        }

        var user = new User
        {
            Username = dto.Username,
            Password = hasher.HashPassword(dto.Password, out byte[] _),
            Role = dto.Role
        };
        return user;
    }
}