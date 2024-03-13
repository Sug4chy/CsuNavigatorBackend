using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Database.Context;

public class NavigatorDbContext(DbContextOptions<NavigatorDbContext> options) : DbContext(options)
{
    public DbSet<Organization> Organizations => Set<Organization>();
    public DbSet<Map> Maps => Set<Map>();
    public DbSet<MarkerPoint> MarkerPoints => Set<MarkerPoint>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}