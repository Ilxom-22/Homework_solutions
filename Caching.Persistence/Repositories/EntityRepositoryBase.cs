using Caching.Domain.Common.Caching;
using Caching.Domain.Common.Entities;
using Caching.Domain.Common.Query;
using Caching.Domain.Extensions;
using Caching.Persistence.Caching.Brokers;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Caching.Persistence.Repositories;

public abstract class EntityRepositoryBase<TContext, TEntity>(
    TContext dbContext,
    ICacheBroker cacheBroker,
    CacheEntryOptions? entryOptions = default
    ) where TContext : DbContext where TEntity : class, IEntity
{
    protected TContext DbContext => dbContext;

    protected IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate = default, bool asNoTracking = false)
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    protected async ValueTask<IList<TEntity>> GetAsync(
        QuerySpecification<TEntity> querySpecification,
        bool asNoTracking = false,
        CancellationToken cancellationToken = default
    )
    {
        var foundEntities = new List<TEntity>();

        var cacheKey = querySpecification.CacheKey;

        if (entryOptions is null || !await cacheBroker.TryGetAsync<List<TEntity>>(cacheKey, out var cachedEntities))
        {
            var initialQuery = DbContext.Set<TEntity>().AsQueryable();
            if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

            initialQuery = initialQuery.ApplySpecification(querySpecification);

            foundEntities = await initialQuery.ToListAsync(cancellationToken);

            if (entryOptions is not null)
            {
                await cacheBroker.SetAsync(cacheKey, foundEntities, entryOptions);
                await cacheBroker.AddCollectionKeyAsync(cacheKey);
            }
        }
        else
        {
            foundEntities = cachedEntities;
        }

        return foundEntities;
    }

    protected async ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        var foundEntity = default(TEntity?);

        if (entryOptions is null || !await cacheBroker.TryGetAsync<TEntity>($"{typeof(TEntity).Name}-{id}", out var cachedEntity))
        {
            var initialQuery = DbContext.Set<TEntity>().AsQueryable();
            if (asNoTracking) initialQuery = initialQuery.AsNoTracking();

            foundEntity = await initialQuery.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);

            if (foundEntity is not null && entryOptions is not null)
                await cacheBroker.SetAsync($"{typeof(TEntity).Name}-{id}", foundEntity, entryOptions);
        }
        else
        {
            foundEntity = cachedEntity;
        }

        return foundEntity;
    }

    protected async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids, 
        bool asNoTracking = false, 
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = DbContext.Set<TEntity>().AsQueryable();

        if (asNoTracking) initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken);
    }

    protected async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        await DbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (entryOptions is not null)
        {
            await cacheBroker.SetAsync($"{typeof(TEntity).Name}-{entity.Id}", entity, entryOptions);
            await cacheBroker.InvalidateAsync(typeof(TEntity).Name);
        }

        if (saveChanges) await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Update(entity);

        if (entryOptions is not null)
        {
            await cacheBroker.SetAsync($"{typeof(TEntity).Name}-{entity.Id}", entity, entryOptions);
            await cacheBroker.InvalidateAsync(typeof(TEntity).Name);
        }

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteAsync(TEntity entity, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        DbContext.Set<TEntity>().Remove(entity);

        if (entryOptions is not null)
        {
            await cacheBroker.DeleteAsync<TEntity>($"{typeof(TEntity).Name}-{entity.Id}");
            await cacheBroker.InvalidateAsync(typeof(TEntity).Name);
        }

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    protected async ValueTask<TEntity?> DeleteByIdAsync(Guid id, bool saveChanges = false, CancellationToken cancellationToken = default)
    {
        var entity = await DbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) 
            ?? throw new InvalidOperationException();

        DbContext.Set<TEntity>().Remove(entity);

        if (entryOptions is not null)
        {
            await cacheBroker.DeleteAsync<TEntity>($"{typeof(TEntity).Name}-{entity.Id}");
            await cacheBroker.InvalidateAsync(typeof(TEntity).Name);
        }

        if (saveChanges)
            await DbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}