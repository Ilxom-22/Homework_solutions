using EfCore.Interceptors.Domain.Brokers;
using EfCore.Interceptors.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCore.Interceptors.Persistence.Interceptors;

public class UpdateAuditableInterceptor(IRequestUserContextProvider requestUserContextProvider) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default
    )
    {
        var auditableEntries = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();
        var modificationEntries = eventData.Context!.ChangeTracker
            .Entries<IModificationAuditableEntity>().ToList();
        var creationEntries = eventData.Context!.ChangeTracker.Entries<ICreationAuditableEntity>().ToList();

        auditableEntries.ForEach(entry =>
        {
            if (entry.State == EntityState.Modified)
                entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTimeOffset.UtcNow;

            if (entry.State == EntityState.Added)
                entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTimeOffset.UtcNow;
        });

        modificationEntries.ForEach(entry =>
        {
            if (entry.State == EntityState.Modified)
                entry.Property(nameof(IModificationAuditableEntity.ModifiedByUserId)).CurrentValue = requestUserContextProvider.GetUserId();
        });

        creationEntries.ForEach(entry =>
        {
            if (entry.State == EntityState.Added)
                entry.Property(nameof(ICreationAuditableEntity.CreatedByUserId)).CurrentValue = requestUserContextProvider.GetUserId();
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}