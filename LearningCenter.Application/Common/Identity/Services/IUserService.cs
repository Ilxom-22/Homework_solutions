using LearningCenter.Domain.Entities.Common.Identity;
using System.Linq.Expressions;

namespace LearningCenter.Application.Common.Identity.Services;

public interface IUserService
{
    IQueryable<User> Get(Expression<Func<User, bool>>? predicate);

    ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}