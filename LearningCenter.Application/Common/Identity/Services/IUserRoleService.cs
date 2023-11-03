using LearningCenter.Domain.Entities.Common.Identity;
using System.Linq.Expressions;

namespace LearningCenter.Application.Common.Identity.Services;

public interface IUserRoleService
{
    IQueryable<UserRole> Get(Expression<Func<UserRole, bool>>? predicate);

    ValueTask<UserRole?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    ValueTask<UserRole> CreateAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserRole> UpdateAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserRole> DeleteAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<UserRole> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default);
}