﻿using CsuNavigatorBackend.ApplicationServices.Dto;
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
            Password = hasher.HashPassword(dto.Password),
            Role = dto.Role
        };
        return user;
    }

    public Task<User?> GetUserByUsernameAndRoleAsync(string username, Role role, CancellationToken ct = default)
        => context.Users
            .Include(u => u.Profile)
            .FirstOrDefaultAsync(u => u.Username == username
            && u.Role == role, ct);
}