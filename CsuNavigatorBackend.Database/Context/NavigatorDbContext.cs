using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Database.Context;

public class NavigatorDbContext(DbContextOptions<NavigatorDbContext> options) : DbContext(options)
{
    public DbSet<Map> Maps => Set<Map>();
    public DbSet<Organization> Organizations => Set<Organization>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}