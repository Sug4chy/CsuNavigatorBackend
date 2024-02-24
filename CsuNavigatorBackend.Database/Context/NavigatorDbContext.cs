using Microsoft.EntityFrameworkCore;

namespace CsuNavigatorBackend.Database.Context;

public class NavigatorDbContext(DbContextOptions<NavigatorDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}