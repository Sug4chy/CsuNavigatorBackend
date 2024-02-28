using CsuNavigatorBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CsuNavigatorBackend.Database.Context.Interceptors;

public class UpdateAuditableEntitiesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var context = eventData.Context;
        if (context is null)
        {
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        foreach (var entry in context.ChangeTracker.Entries<Entity>())
        {
            switch (entry.State)
            {
                case EntityState.Detached:
                    break;
                case EntityState.Unchanged:
                    break;
                case EntityState.Deleted:
                    entry.Property(e => e.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(e => e.DeletedAt).CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Property(e => e.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entry.Property(e => e.CreatedAt).CurrentValue = DateTime.UtcNow;
                    entry.Property(e => e.LastlyEditedAt).CurrentValue = DateTime.UtcNow;
                    break;
                default:
                    continue;
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}