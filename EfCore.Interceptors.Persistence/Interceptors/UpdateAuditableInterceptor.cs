﻿using EfCore.Interceptors.Domain.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCore.Interceptors.Persistence.Interceptors;

public class UpdateAuditableInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData, 
        InterceptionResult<int> result, 
        CancellationToken cancellationToken = default
    )
    {
        var auditableEntries = eventData.Context!.ChangeTracker.Entries<IAuditableEntity>().ToList();

        auditableEntries.ForEach(entry =>
        {
            if (entry.State == EntityState.Modified)
                entry.Property(nameof(IAuditableEntity.ModifiedTime)).CurrentValue = DateTimeOffset.UtcNow;

            if (entry.State == EntityState.Added)
                entry.Property(nameof(IAuditableEntity.CreatedTime)).CurrentValue = DateTimeOffset.UtcNow;
        });

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}