using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using LearningCenter.Persistence.DataContexts;
using System.Linq.Expressions;

namespace LearningCenter.Infrastructure.Common.Identity.Services;

public class UserRoleService : IUserRoleService
{
    private readonly AppDbContext _appDbContext;

    public UserRoleService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<UserRole> Get(Expression<Func<UserRole, bool>>? predicate)
        => predicate != null ? _appDbContext.Roles.Where(predicate) : _appDbContext.Roles;

    public ValueTask<UserRole?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _appDbContext.Roles.FindAsync(id);

    public async ValueTask<UserRole> CreateAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _appDbContext.Roles.AddAsync(userRole, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return userRole;
    }

    public async ValueTask<UserRole> UpdateAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundRole = await GetByIdAsync(userRole.Id, cancellationToken) ?? throw new ArgumentException("User role not found!");

        foundRole.Role = userRole.Role;
        foundRole.UserId = userRole.UserId;

        _appDbContext.Roles.Update(foundRole);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return userRole;
    }

    public async ValueTask<UserRole> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundRole = await GetByIdAsync(id, cancellationToken) ?? throw new ArgumentException("User role not found");

        _appDbContext.Roles.Remove(foundRole);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundRole;
    }

    public async ValueTask<UserRole> DeleteAsync(UserRole userRole, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteByIdAsync(userRole.Id, saveChanges, cancellationToken);
}