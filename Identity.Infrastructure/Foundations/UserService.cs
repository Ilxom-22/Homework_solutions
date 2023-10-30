using Identity.Application.Foundations;
using Identity.Domain.Entities;
using Identity.Persistence.DataContext;
using System.Linq.Expressions;

namespace Identity.Infrastructure.Foundations;

public class UserService : IEntityBaseService<User>
{
    private readonly IDataContext _appFileContext;

    public UserService(IDataContext context)
        => _appFileContext = context;

    public IQueryable<User> Get(Expression<Func<User, bool>> predicate)
        => _appFileContext.Users.Where(predicate.Compile()).AsQueryable();

    public async ValueTask<User> GetByIdAsync(Guid id)
        => await _appFileContext.Users.FindAsync(id) ?? throw new ArgumentOutOfRangeException(nameof(id), "User not found!");

    public async ValueTask<User> CreateAsync(User user)
    {
        if (!IsValidUser(user))
            throw new ArgumentException("Invalid user");

        if (!IsUnique(user))
            throw new ArgumentException("Username or email address already exists!");

        await _appFileContext.Users.AddAsync(user);
        await _appFileContext.SaveChangesAsync();

        return user;
    }

    public async ValueTask<User> UpdateAsync(User user)
    {
        var foundUser = await GetByIdAsync(user.Id);

        foundUser.IsEmailAddressVerified = user.IsEmailAddressVerified;
        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;

        await _appFileContext.Users.UpdateAsync(foundUser);

        await _appFileContext.SaveChangesAsync();

        return foundUser;
    }

    private bool IsValidUser(User user)
        => !string.IsNullOrWhiteSpace(user.Username)
            && !string.IsNullOrWhiteSpace(user.FirstName)
            && !string.IsNullOrWhiteSpace(user.LastName)
            && !string.IsNullOrWhiteSpace(user.EmailAddress)
            && !string.IsNullOrWhiteSpace(user.PasswordHash);

    private bool IsUnique(User user)
        => !_appFileContext.Users.Any(self => self.Username == user.Username || self.EmailAddress == user.EmailAddress);
}