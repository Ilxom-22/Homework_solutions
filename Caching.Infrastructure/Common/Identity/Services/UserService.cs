using Caching.Application.Common.Identity.Services;
using Caching.Domain.Common.Query;
using Caching.Domain.Entities;
using Caching.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Caching.Infrastructure.Common.Identity.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false)
    {
        return userRepository.Get(predicate, asNoTracking);
    }

    public ValueTask<IList<User>> GetAsync(QuerySpecification<User> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);
    }

    public ValueTask<User?> GetByIdAsync(Guid id, bool asNoTracking = false, CancellationToken cancellationToken = default)
    {
        return userRepository.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    public ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.UpdateAsync(user, saveChanges, cancellationToken);
    }

    public ValueTask<User?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteByIdAsync(id, saveChanges, cancellationToken);
    }

    public ValueTask<User?> DeleteAsync(User user, bool saveCahnges = true, CancellationToken cancellationToken = default)
    {
        return userRepository.DeleteAsync(user, saveCahnges, cancellationToken);
    }
}