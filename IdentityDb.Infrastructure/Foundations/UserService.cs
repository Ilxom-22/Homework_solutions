using IdentityDb.Application.Common.Identity.Foundations;
using IdentityDb.Domain.Entities;
using IdentityDb.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace IdentityDb.Infrastructure.Foundations;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository) =>
        _userRepository = userRepository;

    public IQueryable<User> Get(Expression<Func<User, bool>>? predicate = null, bool asNoTracking = false) =>
        _userRepository.Get(predicate, asNoTracking);

    public async ValueTask<User> CreateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidUser(user))
            throw new ArgumentException(nameof(User));

        if (!IsUnique(user))
            throw new ArgumentException(nameof(User));

        return await _userRepository.CreateAsync(user, saveChanges, cancellationToken);
    }

    public async ValueTask<User> UpdateAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        if (!IsValidUser(user))
            throw new ArgumentException(nameof(User));

        var foundUser = await _userRepository.GetByIdAsync(user.Id, cancellationToken: cancellationToken) 
            ?? throw new InvalidOperationException("User not found!");

        foundUser.FirstName = user.FirstName;
        foundUser.LastName = user.LastName;
        foundUser.IsEmailVerified = user.IsEmailVerified;
        foundUser.PasswordHash = user.PasswordHash;

        return await _userRepository.UpdateAsync(foundUser, saveChanges, cancellationToken);
    }

    private static bool IsValidUser(User user) => 
        !(string.IsNullOrWhiteSpace(user.FirstName) 
        || string.IsNullOrWhiteSpace(user.LastName) 
        || string.IsNullOrWhiteSpace(user.EmailAddress)
        || string.IsNullOrWhiteSpace(user.PasswordHash));

    private bool IsUnique(User user) =>
        !_userRepository.Get(asNoTracking: true).Any(self => self.EmailAddress == user.EmailAddress);
}