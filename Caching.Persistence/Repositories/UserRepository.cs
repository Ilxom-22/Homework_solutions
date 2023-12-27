using Caching.Domain.Common.Caching;
using Caching.Domain.Common.Query;
using Caching.Domain.Entities;
using Caching.Persistence.Caching.Brokers;
using Caching.Persistence.DataContexts;
using Caching.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Caching.Persistence.Repositories;

public class UserRepository(IdentityDbContext dbContext, ICacheBroker cachBroker)
    : EntityRepositoryBase<IdentityDbContext, User>(dbContext, cachBroker, new CacheEntryOptions()), IUserRepository
{
    public new IQueryable<User> Get(Expression<Func<User, bool>>? predicate = default, bool asNoTracking = false)
    {
        return base.Get(predicate, asNoTracking);
    }

    public new ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public new ValueTask<User?> GetByIdAsync(Guid userId, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return base.GetByIdAsync(userId, asNoTracking, cancellationToken);
    }

    public new ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.CreateAsync(user, saveChanges, cancellationToken);
    }

    public new ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public new ValueTask<User?> DeleteByIdAsync(Guid userId, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteByIdAsync(userId, saveChanges, cancellationToken);
    }

    public new ValueTask<User?> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return base.DeleteAsync(user, saveChanges, cancellationToken);
    }
}