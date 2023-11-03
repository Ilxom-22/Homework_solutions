using LearningCenter.Application.Common.Identity.Services;
using LearningCenter.Domain.Entities.Common.Identity;
using LearningCenter.Persistence.DataContexts;
using System.Linq.Expressions;

namespace LearningCenter.Infrastructure.Common.Identity.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _appDbContext;

    public UserService(AppDbContext appDataContext)
        => _appDbContext = appDataContext;

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate)
        => predicate != null ? _appDbContext.Users.Where(predicate) : _appDbContext.Users;

    public ValueTask<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => _appDbContext.Users.FindAsync(id, cancellationToken);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        user.Id = Guid.Empty;

        await _appDbContext.Users.AddAsync(user, cancellationToken);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(user.Id, cancellationToken);

        if (foundUser is null)
            throw new ArgumentException("User not found!");

        _appDbContext.Users.Update(user);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return user;
    }

    public async ValueTask<User> DeleteAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteByIdAsync(user.Id, saveChanges, cancellationToken);

    public async ValueTask<User> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUser = await GetByIdAsync(id, cancellationToken);

        if (foundUser is null)
            throw new ArgumentException("User not found!");

        _appDbContext.Users.Remove(foundUser);

        if (saveChanges) await _appDbContext.SaveChangesAsync(cancellationToken);

        return foundUser;
    }
}