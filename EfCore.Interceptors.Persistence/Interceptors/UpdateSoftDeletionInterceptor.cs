using EfCore.Interceptors.Domain.Brokers;
using EfCore.Interceptors.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCore.Interceptors.Persistence.Interceptors;

public class UpdateSoftDeletionInterceptor(IRequestUserContextProvider requestUserContextProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default
    )
    {
        var softDeletionEntries = eventData.Context!.ChangeTracker.Entries<ISoftDeletedEntity>().ToList();
        var deletionEntries = eventData.Context!.ChangeTracker.Entries<IDeletionAuditableEntity>().ToList();

        deletionEntries.ForEach(entry =>
        {
            if (entry.State == EntityState.Deleted)
                entry.Property(nameof(IDeletionAuditableEntity.DeletedByUserId)).CurrentValue = requestUserContextProvider.GetUserId();
        });

        softDeletionEntries.ForEach(
            entry =>
            {
                if (entry.State == EntityState.Deleted)
                {
                    entry.State = EntityState.Modified;
                    entry.Property(nameof(ISoftDeletedEntity.DeletedTime)).CurrentValue = DateTimeOffset.UtcNow;
                    entry.Property(nameof(ISoftDeletedEntity.IsDeleted)).CurrentValue = true;
                }
            });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}